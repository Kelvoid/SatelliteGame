using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Light))]

public class Satellite : MonoBehaviour {

    public Color satelliteColor;
    Color mainColor;

    GameManager gameManager;
    MeshRenderer satelliteMesh;
    TrailRenderer satelliteTrail;
    Light satelliteLight;
    Camera mainCamera;

    Material material;
    public Material satelliteMeshMaterial;

    public Vector3 satellitePosition;
    Vector3 screenPos;

    internal Transform origin;

    internal float speed;
    internal float distance;
    internal float angle;
    internal float lightRange;

    internal Vector3 cameraPosition;
    public float meshRenderDistance;
    internal float cameraDistance;

    public float focusedLight;

    internal float lightIntensity;
    internal float blinkRate;

    //Identifiers
    public float idNumber;
    public string manufacturer;

    internal float distanceFromCenter;

    void Awake ()
    {
        mainColor = satelliteColor;

        satelliteTrail = gameObject.GetComponent<TrailRenderer>();
        satelliteLight = gameObject.GetComponent<Light>();
        gameManager = FindObjectOfType<GameManager>();
        satelliteMesh = FindObjectOfType<MeshRenderer>();
        mainCamera = FindObjectOfType<Camera>();
    }

    void Start()
    {
        satelliteTrail.endWidth = 0;
        SetColor(mainColor);
        satelliteLight.range = lightRange;
        satelliteMesh.enabled = false;
        satelliteMesh.material = satelliteMeshMaterial;
        gameObject.transform.position = satellitePosition;
    }
	
    void SetColor(Color color)
    {
        satelliteTrail.startColor = color;
        satelliteTrail.endColor = color;
        satelliteLight.color = color;
    }

    void Update()
    {
        cameraDistance = Vector3.Distance(gameObject.transform.position, mainCamera.transform.position);             
        screenPos = gameManager.mainCamera.WorldToScreenPoint(satellitePosition);

        if(cameraDistance < meshRenderDistance)
        {
            satelliteMesh.enabled = true;
        }
        else
        {
            satelliteMesh.enabled = false;
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
            satelliteLight.range = focusedLight;
        }
    }
}
