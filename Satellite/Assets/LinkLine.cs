using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LinkLine : MonoBehaviour
{
    LineRenderer line;

    public Vector3 posOne;
    public Vector3 posTwo;

	void Start ()
    {
        line = GetComponent<LineRenderer>();
	}

	public void setPoints (Vector3 pointOne, Vector3 pointTwo)
    {
        line.SetPosition(0, pointOne);
        line.SetPosition(1, pointTwo);
    }
}
