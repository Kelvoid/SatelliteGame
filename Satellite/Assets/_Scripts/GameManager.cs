using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject currentFocus;
    public GameObject lastDestination;
    public GameObject lastFocus;

    public GameObject home;

    public LinkLine linkLine;
    public Camera mainCamera;
    public StateManager stateManager;

    public float meshRenderDistance;
    public float focalRange;
    internal Vector2 screenCenter;

    public Vector3 targetPosition;
    public Vector2 focusScreenPos;

    void Awake()
    {
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

	void FixedUpdate()
    {   
        if(currentFocus != null && currentFocus.GetComponent<FocusTarget>().distanceFromCenter < focalRange)
        {
            focusScreenPos = mainCamera.WorldToScreenPoint(currentFocus.transform.position);
        } 
           
        if (currentFocus != null && currentFocus.GetComponent<FocusTarget>().distanceFromCenter > focalRange)
        {         
            lastFocus = currentFocus;
            currentFocus = null;
        }
    }
}
