using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedLerp : MonoBehaviour
{
    public bool isLerping = false;

    public float travelTime;
    private float percentage;

    private float timeStartedLerping;

    internal Vector3 startPos;
    internal Vector3 targetPos;

    internal GameObject lerpObject;

    void FixedUpdate ()
    {
        if (isLerping)
        {
            float timeSinceStarted = Time.time - timeStartedLerping;
            float percentageComplete = timeSinceStarted / travelTime;
            lerpObject.transform.position = Vector3.Lerp(startPos, targetPos, percentageComplete);
            if (percentageComplete >= percentage)
            {
                isLerping = false;
            }
        }
	}

    public void StartLerping(GameObject objectToLerp, Vector3 target, float timeToDestination, float percentToTravel)
    {
        isLerping = true;
        timeStartedLerping = Time.time;
        lerpObject = objectToLerp;
        startPos = objectToLerp.transform.position;
        targetPos = target;
        percentage = percentToTravel;
        travelTime = timeToDestination;
    }
}
