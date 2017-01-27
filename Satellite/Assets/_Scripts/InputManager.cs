using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    internal GameManager gameManager;
    internal StateManager stateManager;
    internal CameraMovement cameraMovement;
    internal Cutoff cutoff;

    internal bool lockControl;

    [Range(0, 1)]
    public float percent;

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
        if(stateManager.isInteracting == true)
        {
            CursorUnlocked();
        }
        else
        {
            CursorLocked();
        }

        if(lockControl == false)
        {

            if (Input.GetMouseButtonDown(0)) //Left Click
            {
                LeftClick();
            }

            if (Input.GetMouseButtonDown(1)) //Right Click
            {
                RightClick();
            }
        }
    }

    void LeftClick()
    {
        if (stateManager.shellUp == true && stateManager.isHome)
        {
            cutoff.StartLerpingCutoff(Mathf.Clamp01(1f), Mathf.Clamp01(1f), Mathf.Clamp01(1f));
        }

        else if (stateManager.shellUp == false && gameManager.currentFocus != null && gameManager.currentFocus != gameManager.lastDestination)
        {

            cameraMovement.StartLerping(gameManager.currentFocus.transform.position, percent);
        }

        else if (gameManager.currentFocus != null && gameManager.currentFocus == gameManager.lastFocus)
        {
            Debug.Log("Interacting with " + gameManager.currentFocus.name);
        }
    }

    void RightClick()
    {
        if (stateManager.isHome)
        {
            cutoff.StartLerpingCutoff(Mathf.Clamp01(0f), Mathf.Clamp01(1f), Mathf.Clamp01(1f));
            gameManager.lastDestination = null;
        }
        else if (stateManager.isHome == false)
        {
            cameraMovement.StartLerping(new Vector3(0,0,0), 1);
        }
    }

    void CursorUnlocked()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void CursorLocked()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
