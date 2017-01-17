using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameManager gameManager;
    public StateManager stateManager;
    public CameraMovement cameraMovement;
    public Cutoff cutoff;

    int screenWidth;
    int screenHeight;

    Vector3 mousePosition;

    Input leftClick;
    Input rightClick;

    void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
        stateManager = FindObjectOfType<StateManager>();
        cameraMovement = GetComponent<CameraMovement>();
        cutoff = FindObjectOfType<Cutoff>();

        screenWidth = Screen.width;
        screenHeight = Screen.height;
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameManager.currentFocus != null)
            {
                cameraMovement.TravelToTarget();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            cameraMovement.TravelHome();
        }
    }
}
