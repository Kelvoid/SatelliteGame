using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Vector3 startPos;
    internal Vector3 targetPos;
    Vector3 defaultPos;

    public float travelTime;

    public bool isTraveling;

    public GameManager gameManager;

    void Start()
    {
        targetPos = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }

	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(TravelToLocation(targetPos, travelTime));
        }
	}

    IEnumerator TravelToLocation(Vector3 target, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        while(elapsedTime < seconds)
        {
            transform.LookAt(target);
            transform.position = Vector3.Lerp(startingPos, target, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();         
        }
        transform.position = target;
    }
}
