using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(Light))]

public class Satellite : MonoBehaviour {

    public Color[] satelliteColors;
    Color mainColor;

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

    internal float focusedLight;

    internal float lightIntensity;
    internal float blinkRate;

    GameManager gameManager;
    internal float distanceFromCenter;

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
        focusedLight = lightRange * 3;
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

        lightIntensity = Mathf.PingPong(Time.time * blinkRate, 5);
        satelliteLight.intensity = lightIntensity;

        screenPos = gameManager.mainCamera.WorldToScreenPoint(satellitePosition);
        distanceFromCenter = Vector2.Distance(screenPos, gameManager.screenCenter);
    }
}
