using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Satellite satellite;

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

    LinkLine linkLine;

    void Start ()
    {      
        Cursor.visible = false;
        screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        linkLine = FindObjectOfType<LinkLine>();

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
        if(currentFocus != null && currentFocus.distanceFromCenter > focalRange)
        {
            currentFocus = null;
        }

        if(currentFocus != null)
        {
            Scanning(currentFocus);
        }

        if(selectionOne != null && selectionTwo != null)
        {
            linkLine.setPoints(selectionOne.transform.position, selectionTwo.transform.position);
        }
    }

    public void Scanning(Satellite currentSatellite)
    {
        Debug.Log(currentSatellite.name);
        if (selectionOne == null)
        {
            selectionOne = currentSatellite;
        }
        else
        {
            selectionTwo = currentSatellite;
        }
    }
}
