using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusTarget : MonoBehaviour
{
    GameManager gameManager;
    internal Vector3 screenPos;
    internal float distanceFromCursor;

    void Awake ()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

	void Update ()
    {
        screenPos = gameManager.mainCamera.WorldToScreenPoint(gameObject.transform.position);
        distanceFromCursor = Vector2.Distance(screenPos, gameManager.inputManager.mousePosition);

        if (gameManager.stateManager.shellUp == false && distanceFromCursor < gameManager.focalRange)
        {
            gameManager.currentFocus = gameObject.GetComponent<FocusTarget>();
        }
    }
}
