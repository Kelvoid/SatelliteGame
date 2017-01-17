using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Light))]

public class Satellite : MonoBehaviour {

    public Color[] satelliteColors;
    Color mainColor;

    GameManager gameManager;
    TrailRenderer satelliteTrail;
    Light satelliteLight;

    Material material;

    Vector3 satellitePosition;
    Vector3 screenPos;

    internal Transform origin;

    internal float speed;
    internal float distance;
    internal float angle;
    internal float lightRange;

    public float focusedLight;

    internal float lightIntensity;
    internal float blinkRate;

    internal float distanceFromCenter;

    //Identifiers
    public string manufacturer;

    void Awake ()
    {
        int randomColor = (Random.Range(0, satelliteColors.Length));
        mainColor = satelliteColors[randomColor];

        satelliteTrail = gameObject.GetComponent<TrailRenderer>();
        satelliteLight = gameObject.GetComponent<Light>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        transform.Rotate(Random.onUnitSphere * 360);
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

    void Update()
    {
        angle += speed * Time.deltaTime;
        Vector3 v = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        transform.localPosition = Vector3.zero;
        v = transform.TransformPoint(v).normalized;
        transform.localPosition = origin.position + v * distance;

        satellitePosition = gameObject.transform.position;
        
        screenPos = gameManager.mainCamera.WorldToScreenPoint(satellitePosition);
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
