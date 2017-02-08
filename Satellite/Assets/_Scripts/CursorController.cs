using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public GameObject cross;
    public GameObject ring;

    GameManager gameManager;
    TargetedLerp targetedLerp;

    void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
        targetedLerp = GetComponentInChildren<TargetedLerp>();
    }

    void Update()
    {
        ring.transform.position = gameManager.inputManager.mousePosition;

        //if(gameManager.inputManager)

        if (gameManager.currentFocus != null)
        {
            if (Vector2.Distance(gameManager.inputManager.mousePosition, gameManager.currentFocus.screenPos) < gameManager.focalRange)
            {
                targetedLerp.StartLerping(cross, gameManager.currentFocus.screenPos, 0.05f, 1);
            } 
        }

        else
        {
            targetedLerp.StartLerping(cross, gameManager.inputManager.mousePosition, 0.05f, 1);
        }

    }

}
