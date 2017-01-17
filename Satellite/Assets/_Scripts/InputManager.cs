using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    internal GameManager gameManager;

    int screenWidth;
    int screenHeight;

    Vector3 screenCenter;
    Vector3 mousePosition;
    Camera mainCamera;

    void Start ()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        if (gameManager == null)
        {
            gameManager = GetComponent<GameManager>();
        }

        if (mainCamera == null)
        {
            mainCamera = GetComponent<Camera>();
        }
        screenCenter = new Vector3(screenWidth * 0.5f, screenHeight * 0.5f, 0);
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Click");
        }
	}

    void Interact()
    {

    }

    void Backout()
    {

    }
}
