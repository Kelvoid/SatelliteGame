using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomeSatelliteMarker : MonoBehaviour {

    Vector3 targetPosition;
    public GameObject target;
    GameManager gameManager;

	void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	void Update ()
    {
        targetPosition = gameManager.mainCamera.WorldToScreenPoint(target.transform.position);
        transform.position = targetPosition;
	}
}
