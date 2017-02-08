using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(Light))]

public class Satellite : MonoBehaviour
{
    Color mainColor;
    GameManager gameManager;
    TrailRenderer satelliteTrail;
    Light satelliteLight;

    [Header("Satellite Properties")]
    public Color satelliteColor;
    public Mesh satelliteMesh;
    public Material satelliteMeshMaterial;

    public GameObject MeshHolder;

    public float blinkRate;
    public float idNumber;
    public string manufacturer;

    internal float lightRange = 1;
    internal float cameraDistance;
    internal float lightIntensity;

    void Awake ()
    {
        mainColor = satelliteColor;
        satelliteTrail = gameObject.GetComponent<TrailRenderer>();
        satelliteLight = gameObject.GetComponent<Light>();
        gameManager = FindObjectOfType<GameManager>();

        gameObject.name = manufacturer + "  " + idNumber;
    }

    void Start()
    {
        satelliteTrail.endWidth = 0;
        SetColor(mainColor);
        satelliteLight.range = lightRange;
    }
	
    void SetColor(Color color)
    {
        satelliteTrail.startColor = color;
        satelliteTrail.endColor = color;
        satelliteLight.color = color;
    }

    void CameraClose()
    {       
        MeshHolder.SetActive(true);
    }

    void CameraFar()
    {
        MeshHolder.SetActive(false);
    }

    void Blink()
    {
        lightIntensity = Mathf.PingPong(Time.time * blinkRate, 5);
        satelliteLight.intensity = lightIntensity;
        satelliteLight.range = lightRange;
    }

    void Update()
    {
        cameraDistance = Vector3.Distance(gameObject.transform.position, gameManager.mainCamera.transform.position);                   

        if(cameraDistance < gameManager.meshRenderDistance)
        {
            CameraClose();
        }
        else
        {
            CameraFar();
            Blink();
        }
    }
}
