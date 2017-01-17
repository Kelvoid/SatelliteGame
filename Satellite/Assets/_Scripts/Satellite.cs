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

    Vector3 satellitePosition;
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
        transform.Rotate(Random.onUnitSphere * 360);
        satelliteTrail.endWidth = 0;
        SetColor(mainColor);
        satelliteLight.range = lightRange;
        satelliteMesh.enabled = false;
        satelliteMesh.material = satelliteMeshMaterial;
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
        angle += speed * Time.deltaTime;
        Vector3 v = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        transform.localPosition = Vector3.zero;
        v = transform.TransformPoint(v).normalized;
        transform.localPosition = origin.position + v * distance;
        satellitePosition = gameObject.transform.position;        
        screenPos = gameManager.mainCamera.WorldToScreenPoint(satellitePosition);

        if(cameraDistance < meshRenderDistance)
        {
            satelliteMesh.enabled = true;
        }
        else
        {
            satelliteMesh.enabled = false;
        }

        if (screenPos.z < 0)  //cale tweak - stops you from selecting satalites on the other side of the world, WorldToScreenPoint is weird like that, just how projections work
            return;

        lightIntensity = Mathf.PingPong(Time.time * blinkRate, 5);  //cale tweak - moved this below, no point in exicuting the code if object is on other side of world
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
