using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    internal GameManager gameManager;
    internal StateManager stateManager;
    public StarController stars;

    public float travelTime;
    public float percentage;
    
    public bool isLerping = false;
    private float timeStartedLerping;

    internal Vector3 startPos;
    internal Vector3 targetPos;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        stateManager = FindObjectOfType<StateManager>();
    }

    void FixedUpdate()
    {
        if (isLerping)
        {
            stateManager.isTravelling = true;
            float timeSinceStarted = Time.time - timeStartedLerping;
            float percentageComplete = timeSinceStarted / travelTime;
            transform.position = Vector3.Lerp(startPos, targetPos, percentageComplete);

            if (percentageComplete >= percentage)
            {
                stateManager.isTravelling = false;
                isLerping = false;
            }
        }
    }

    public void StartLerping(Vector3 target, float offset)
    {
        gameManager.lastDestination = gameManager.currentFocus;

        if(isLerping == false)
        {
            isLerping = true;
            timeStartedLerping = Time.time;
            startPos = transform.position;
            percentage = offset;
            targetPos = target;
        }
    }

    public void MouseLook()
    {

    }
}
