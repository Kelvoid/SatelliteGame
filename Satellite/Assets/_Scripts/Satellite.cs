using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Light))]

public class Satellite : MonoBehaviour {

    Color mainColor;
    GameManager gameManager;
    MeshRenderer satelliteMeshRenderer;
    MeshFilter satelliteMeshFilter;
    TrailRenderer satelliteTrail;
    Light satelliteLight;
    Material satelliteMaterial;

    Vector3 satellitePosition;
    Vector3 screenPos;

    [Header("Satellite Properties")]
    public Color satelliteColor;
    public Mesh satelliteMesh;
    public Material satelliteMeshMaterial;

    public float blinkRate;
    public float idNumber;
    public string manufacturer;

    internal float lightRange = 1;
    internal float cameraDistance;
    internal float lightIntensity;

    internal float distanceFromCenter;

    void Awake ()
    {
        mainColor = satelliteColor;
        satelliteTrail = gameObject.GetComponent<TrailRenderer>();
        satelliteLight = gameObject.GetComponent<Light>();
        gameManager = FindObjectOfType<GameManager>();
        satelliteMeshRenderer = GetComponent<MeshRenderer>();
        satelliteMeshFilter = GetComponent<MeshFilter>();

        gameObject.name = manufacturer + idNumber;
    }

    void Start()
    {
        satelliteTrail.endWidth = 0;
        SetColor(mainColor);
        satelliteLight.range = lightRange;
        satelliteMeshRenderer.material = satelliteMeshMaterial;
        satelliteMeshFilter.mesh = satelliteMesh;
        satellitePosition = gameObject.transform.position;
    }
	
    void SetColor(Color color)
    {
        satelliteTrail.startColor = color;
        satelliteTrail.endColor = color;
        satelliteLight.color = color;
    }

    void CameraClose()
    {
        satelliteMeshRenderer.enabled = true;
        satelliteLight.enabled = false;
    }

    void CameraFar()
    {
        satelliteMeshRenderer.enabled = false;
        satelliteLight.enabled = true;
    }

    void Update()
    {
        cameraDistance = Vector3.Distance(gameObject.transform.position, gameManager.mainCamera.transform.position);             
        screenPos = gameManager.mainCamera.WorldToScreenPoint(satellitePosition);

        if(cameraDistance < gameManager.meshRenderDistance)
        {
            CameraClose();
        }
        else
        {
            CameraFar();
        }

        if (screenPos.z < 0)
            return;

        lightIntensity = Mathf.PingPong(Time.time * blinkRate, 5);
        satelliteLight.intensity = lightIntensity;
        satelliteLight.range = lightRange;

        distanceFromCenter = Vector2.Distance(screenPos, gameManager.screenCenter);


        if (distanceFromCenter < gameManager.focalRange)    //cale adv - you need to add a check in here to make sure that you are also closer than the currently focused object (is there even is one)
        {
            gameManager.currentFocus = gameObject.GetComponent<Satellite>();
            satelliteLight.range = 3;
        }
    }
}
