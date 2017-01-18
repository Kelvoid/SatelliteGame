using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    internal GameManager gameManager;
    internal StateManager stateManager;
    public StarController stars;

    public GameObject home;

    public float travelTime;
    [Range (0.0f, 1.0f)]
    public float percentageOfDistance;
    bool isLerping;
    private float timeStartedLerping;

    internal Vector3 startPos;
    internal Vector3 targetPos;
    internal Vector3 homePos;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        stateManager = FindObjectOfType<StateManager>();
    }

    void Start()
    {
        targetPos = transform.position;
        homePos = home.transform.position;
    }

    void FixedUpdate()
    {
        if (isLerping)
        {
            float timeSinceStarted = Time.time - timeStartedLerping;
            float percentageComplete = timeSinceStarted / travelTime;

            transform.position = Vector3.Lerp(startPos, targetPos, Mathf.Pow(percentageComplete, 0.5f));

            if (percentageComplete >= percentageOfDistance)
            {
                isLerping = false;
            }
        }
    }

    public void StartLerping(Vector3 target, float percentage)
    {
        if(isLerping == false)
        {
            isLerping = true;
            percentageOfDistance = percentage;
            timeStartedLerping = Time.time;
            startPos = transform.position;
            targetPos = target;
        }
    }

}
