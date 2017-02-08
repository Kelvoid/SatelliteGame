using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FocusTarget currentFocus;
    public GameObject lastDestination;
    public GameObject lastFocus;

    public Camera mainCamera;
    internal CameraMovement cameraMovement;
    internal StateManager stateManager;
    internal InputManager inputManager;
    internal Cutoff cutoff;

    public float meshRenderDistance;
    public float focalRange;
    internal Vector3 screenCenter;

    public Vector3 homePosition;

    void Awake()
    {
        stateManager = GetComponent<StateManager>();
        inputManager = GetComponent<InputManager>();
        cameraMovement = mainCamera.GetComponent<CameraMovement>();
        cutoff = FindObjectOfType<Cutoff>();
    }

    void Start ()
    {
        currentFocus = null;
        lastFocus = null;
        lastDestination = null;
	}

    void Update()
    {
        screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f,0);

        Debug.Log(currentFocus);

        if(currentFocus != null && currentFocus.distanceFromCursor >= focalRange)
        {
            currentFocus = null;
        }
    }
}
