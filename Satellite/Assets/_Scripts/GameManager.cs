using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Satellite satellite;
    public LinkLine linkLine;

    public int spawnNumber;

    public Transform origin;

    public float maxSatelliteSpeed;
    public float minSatelliteSpeed;
    public float maxSatelliteDistance;
    public float minSatelliteDistance;

    public float satelliteSize;

    public float maxBlinkRate;
    public float minBlinkRate;

    public Camera mainCamera;
    public float focalRange;
    internal Vector2 screenCenter;

    public float scanTime;
    public float focusedLight;

    public Satellite currentFocus;

    public Satellite selectionOne;
    public Satellite selectionTwo;

    public CameraMovement cameraMovement;

    public Vector3 targetPosition;

    void Start ()
    {      
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        cameraMovement = mainCamera.GetComponent<CameraMovement>();
        //linkLine = FindObjectOfType<LinkLine>();

        currentFocus = null;
        selectionOne = null;
        selectionTwo = null;

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
            //cameraMovement.targetPos = transform.position;
        }

        if(currentFocus != null)
        {
            cameraMovement.targetPos = currentFocus.transform.position;
            //targetPosition = currentFocus.transform.position;
        }
        //cale tweak - added a more indepth debug
        Debug.Log("Current:" + (currentFocus==null?"null":currentFocus.name)+
                    " - SelectionOne:" + (selectionOne == null ? "null" : selectionOne.name) +
                    " - SelectionTwo:" + (selectionTwo == null ? "null" : selectionTwo.name));
        if (selectionOne != null && selectionTwo != null)
        {
            //Instantiate<LinkLine>(linkLine.setPoints(selectionOne.transform.position, selectionTwo.transform.position));
            //linkLine.setPoints(selectionOne.transform.position, selectionTwo.transform.position);//cale adv - you should spawn a new line here provided the two satalites dont already have one connecting them~
        }       
    }

    void StateManager()
    {

    }
}
