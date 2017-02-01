using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusTarget : MonoBehaviour
{
    GameManager gameManager;

    Vector3 screenPos;
    internal float distanceFromCenter;

    void Awake ()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

	void Update ()
    {
        if (screenPos.z < 0)
            return;
        screenPos = gameManager.mainCamera.WorldToScreenPoint(gameObject.transform.position);
        
        distanceFromCenter = Vector2.Distance(screenPos, gameManager.screenCenter);

        if (distanceFromCenter < gameManager.focalRange)
        {
            gameManager.currentFocus = gameObject;
        }
    }
}
