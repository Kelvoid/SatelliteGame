using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Satellite currentFocus;
    public Satellite lastDestination;
    public Satellite lastFocus;

    public LinkLine linkLine;
    public Transform origin;
    public Camera mainCamera;
    public CameraMovement cameraMovement;
    public StateManager stateManager;

    public float meshRenderDistance;
    public float focalRange;
    internal Vector2 screenCenter;

    public Vector3 targetPosition;
    public Vector2 focusScreenPos;

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
        lastFocus = null;
        lastDestination = null;
	}

	void Update ()
    {   
        if(currentFocus != null && currentFocus.distanceFromCenter < focalRange)
        {
            focusScreenPos = mainCamera.WorldToScreenPoint(currentFocus.transform.position);
        } 
           
        if (currentFocus != null && currentFocus.distanceFromCenter > focalRange)
        {
            
            lastFocus = currentFocus;
            currentFocus = null;
        }
    }
}
