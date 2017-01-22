using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Satellite satellite;
    public Satellite currentFocus;
    public LinkLine linkLine;
    public Transform origin;
    public Camera mainCamera;
    public CameraMovement cameraMovement;
    public StateManager stateManager;

    public int spawnNumber;

    public float maxSatelliteSpeed;
    public float minSatelliteSpeed;
    public float maxSatelliteDistance;
    public float minSatelliteDistance;

    public float satelliteSize;

    public float maxBlinkRate;
    public float minBlinkRate;


    public float focalRange;
    internal Vector2 screenCenter;

    public float scanTime;
    public float focusedLight;
    public Vector3 targetPosition;

    void Awake()
    {
        cameraMovement = mainCamera.GetComponent<CameraMovement>();
        stateManager = GetComponent<StateManager>();
    }

    void Start ()
    {
        stateManager.isHome = true;
        screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        currentFocus = null;

        for (int i = 0; i < spawnNumber; i ++)
        {
            Satellite s = Instantiate<Satellite>(satellite);
            s.name += " " + i;
            s.origin = origin;
            s.angle = Random.value * Mathf.PI * 2;
            s.speed = Random.Range(minSatelliteSpeed, maxSatelliteSpeed);
            s.distance = Random.Range(minSatelliteDistance, maxSatelliteDistance);
            s.lightRange = satelliteSize;
            s.blinkRate = Random.Range(minBlinkRate, maxBlinkRate);
        }       
	}

	void Update ()
    {
        if (currentFocus != null && currentFocus.distanceFromCenter > focalRange)
        {
            currentFocus = null;
        }

        if(currentFocus != null)
        {
            //cameraMovement.targetPos = currentFocus.transform.position;
        }
    }
}
