using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameManager gameManager;

    int screenWidth;
    int screenHeight;

    public GameObject reticle;

    Vector3 mousePosition;
    Camera mainCamera;

    void Start ()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        gameManager = GetComponent<GameManager>();
        mainCamera = GetComponent<Camera>();
	}
	
	void Update ()
    {
        mousePosition = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        Vector3 cameraTarget = new Vector3 (ray.direction.x,ray.direction.y,ray.direction.z);
        Vector3 cameraRot = transform.rotation.eulerAngles;

        gameObject.transform.LookAt(cameraTarget);
        

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Click");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Click");
        }
	}
}
