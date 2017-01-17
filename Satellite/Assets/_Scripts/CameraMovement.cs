using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    internal GameManager gameManager;
    internal StateManager stateManager;
    public StarController stars;

    internal Vector3 startPos;
    internal Vector3 targetPos;
    internal Vector3 homePos;

    public Vector3 offset;

    public float travelTime;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        stateManager = FindObjectOfType<StateManager>();
    }

    void Start()
    {
        targetPos = transform.position;
        homePos = new Vector3(0, 0, 0);             
    }

    public void TravelToTarget()
    {
        StopAllCoroutines();
        targetPos = gameManager.currentFocus.transform.position;
        StartCoroutine(TravelToLocation(targetPos, travelTime));
    }

    public void TravelHome()
    {
        StopAllCoroutines();
        StartCoroutine(TravelToLocation(homePos, travelTime));
    }

    public IEnumerator TravelToLocation(Vector3 target, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        while(elapsedTime < seconds)
        {
            transform.LookAt(target);
            transform.position = Vector3.Lerp(startingPos, target - offset, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();         
        }
        stateManager.isTravelling = false;
    }   
}
