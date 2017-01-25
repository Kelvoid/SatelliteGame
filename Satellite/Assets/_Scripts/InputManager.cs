using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameManager gameManager;
    public StateManager stateManager;
    public CameraMovement cameraMovement;
    public Cutoff cutoff;

    Vector3 mousePosition;

    Input leftClick;
    Input rightClick;

    void Start ()
    {
        Cursor.visible = false;
        gameManager = FindObjectOfType<GameManager>();
        stateManager = FindObjectOfType<StateManager>();
        cameraMovement = GetComponent<CameraMovement>();
        cutoff = FindObjectOfType<Cutoff>();
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (stateManager.shellUp == true && stateManager.isHome)
            {
                cutoff.StartLerpingCutoff(Mathf.Clamp01(1f), Mathf.Clamp01(1f), Mathf.Clamp01(1f));
            }

            else if (stateManager.shellUp == false && gameManager.currentFocus != null)
            {
                cameraMovement.StartLerping(gameManager.currentFocus.transform.position, 5f);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (stateManager.isHome)
            {
                cutoff.StartLerpingCutoff(Mathf.Clamp01(0f), Mathf.Clamp01(1f), Mathf.Clamp01(1f));
            }
            else
            {
                cameraMovement.StartLerping(cameraMovement.homePos, 1f);
            }
        }
    }
}
