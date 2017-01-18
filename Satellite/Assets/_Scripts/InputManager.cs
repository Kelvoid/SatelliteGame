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
            cutoff.LerpCutoffTo(1f, 1f);

            if (gameManager.currentFocus != null)
            {
                cameraMovement.StartLerping(gameManager.currentFocus.transform.position, 0.9f);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (stateManager.isHome)
            {
                cutoff.LerpCutoffTo(1f, 0f);
            }

            cameraMovement.StartLerping(cameraMovement.homePos, 1f);
        }
    }
}
