using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutoff : MonoBehaviour
{

    float alphaCutoff;
    Material material;
    StateManager stateManager;
    float alpha;

    private bool isLerping = false;
    private float timeStartedLerping;
    private float percentageOfCutoff;
    internal float cutoffTime;

    internal float startValue;
    internal float targetValue;

    string shaderValue = "_Cutoff";

    void Start ()
    {
        material = gameObject.GetComponent<Renderer>().material;
        stateManager = FindObjectOfType<StateManager>();
    }

    void FixedUpdate()
    {
        if (material.GetFloat(shaderValue) <= 0.8)
        {
            //Debug.Log("Shell Up");
            stateManager.shellUp = true;
        }
        else if (material.GetFloat(shaderValue) > 0.8f)
        {
            //Debug.Log("Shell Down");
            stateManager.shellUp = false;
        }

        if (isLerping)
        {
            float timeSinceStarted = Time.time - timeStartedLerping;
            float percentageComplete = timeSinceStarted / cutoffTime;

            float currentPercentage = Mathf.Lerp(startValue, targetValue, percentageComplete);

            material.SetFloat(shaderValue, currentPercentage);

            if (percentageComplete >= percentageOfCutoff)
            {
                //Debug.Log("Done Lerping");
                isLerping = false;
            }
        }
    }

    public void StartLerpingCutoff(float target, float percentage, float duration)
    {
        if(isLerping == false)
        {
            //Debug.Log("Began Lerping");
            isLerping = true;
            percentageOfCutoff = percentage;
            cutoffTime = duration;
            timeStartedLerping = Time.time;
            startValue = material.GetFloat(shaderValue);
            targetValue = target;
        }
    }
}
