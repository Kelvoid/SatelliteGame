using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    internal GameManager gameManager;
    internal CameraMovement cameraMovement;

    internal bool lockControl;

    internal Vector3 mousePosition;

    internal Ray ray;
    internal RaycastHit hit;

    void Start ()
    {
        Cursor.visible = false;
        CursorUnlocked();
        gameManager = FindObjectOfType<GameManager>();
        cameraMovement = gameManager.mainCamera.GetComponent<CameraMovement>();
	}

    void Update()
    {
        mousePosition = Input.mousePosition;
        ray = gameManager.mainCamera.ScreenPointToRay(mousePosition);

        if (Input.GetAxisRaw("Fire1") == 1)
        {
            Debug.Log("Left Click");
            if(gameManager.currentFocus != null)
            {
                cameraMovement.CameraTravel(gameManager.currentFocus.transform.position);
            }
        }

        if (Input.GetAxisRaw("Fire2") == 1)
        {
            Debug.Log("Right Click");
            cameraMovement.CameraTravel(gameManager.homePosition);
        }
    }

    void CursorUnlocked()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void CursorLocked()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
