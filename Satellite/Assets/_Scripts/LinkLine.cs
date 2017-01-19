using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LinkLine : MonoBehaviour
{
    LineRenderer line;
    GameManager gameManager;

    public GameObject targetOne;
    public GameObject targetTwo;

    Vector3 posOne;
    Vector3 posTwo;

	void Start ()
    {
        line = GetComponent<LineRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        posOne = gameManager.mainCamera.WorldToScreenPoint(targetOne.transform.position);
        posTwo = gameManager.mainCamera.WorldToScreenPoint(targetTwo.transform.position);
        setPoints(posOne, posTwo);
    }

	public void setPoints (Vector3 pointOne, Vector3 pointTwo)
    {
        line.SetPosition(0, pointOne);
        line.SetPosition(1, pointTwo);
    }
}
