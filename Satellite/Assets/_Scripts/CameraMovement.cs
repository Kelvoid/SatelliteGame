using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    internal GameManager gameManager;
    internal TargetedLerp targetedLerp;

   void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        targetedLerp = GetComponent<TargetedLerp>();
    }

    public void MouseLook()
    {

    }

    public void CameraTravel(Vector3 target)
    {
        targetedLerp.StartLerping(gameManager.mainCamera.gameObject, target, 1f, 1);
    }
}
