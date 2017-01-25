using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    internal GameManager gameManager;
    internal StateManager stateManager;
    public StarController stars;

    public GameObject home;

    public float travelTime;
    internal float offset;
    public bool isLerping = false;
    private float timeStartedLerping;

    internal Vector3 startPos;
    internal Vector3 targetPos;
    internal Vector3 homePos;
    internal float distanceFromTarget;

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

        distanceFromTarget = Vector3.Distance(gameObject.transform.position, targetPos);

        if (isLerping)
        {
            float timeSinceStarted = Time.time - timeStartedLerping;
            float percentageComplete = timeSinceStarted / travelTime;
            transform.position = Vector3.Lerp(startPos, targetPos, percentageComplete);
            if (distanceFromTarget <= offset)
            {
                isLerping = false;
            }
        }
    }

    public void StartLerping(Vector3 target, float o)
    {
        if(isLerping == false)
        {
            isLerping = true;
            offset = o;
            timeStartedLerping = Time.time;
            startPos = transform.position;
            targetPos = target;
        }
    }
}
