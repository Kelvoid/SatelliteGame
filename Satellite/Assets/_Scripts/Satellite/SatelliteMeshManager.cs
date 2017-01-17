using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteMeshManager : MonoBehaviour {


    MeshRenderer satelliteMesh;
    Camera mainCamera;

    float cameraDistance;
    public float meshRenderDistance;

	void Start ()
    {
        mainCamera = FindObjectOfType<Camera>();
        satelliteMesh = GetComponent<MeshRenderer>();
	}
	
	void Update ()
    {
        cameraDistance = Vector3.Distance(gameObject.transform.position, mainCamera.transform.position);

        if(cameraDistance > meshRenderDistance)
        {
            satelliteMesh.enabled = false;
        }
        else
        {
            satelliteMesh.enabled = true;
        }
	}
}
