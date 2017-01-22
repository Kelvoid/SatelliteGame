using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class StarController : MonoBehaviour {


    //static GameManager gameManager = FindObjectOfType<GameManager>();
    ParticleSystem stars;
    public Camera mainCamera;
    CameraMovement cameraMovement;

	void Start ()
    {
        stars = gameObject.GetComponent<ParticleSystem>();
        cameraMovement = FindObjectOfType<CameraMovement>();
    }
	
	void Update ()
    {
        var starTrails = stars.trails;

        if (cameraMovement.isLerping == true)
        {
            gameObject.transform.position = mainCamera.transform.position;           
            starTrails.enabled = true;
        }
        else
        {
            starTrails.enabled = false;       
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var starsNoise = stars.noise;
            starsNoise.enabled = !starsNoise.enabled;
        }
	}

    public void ToggleTrails()
    {
        var starsTrails = stars.trails;
        starsTrails.enabled = !starsTrails.enabled;
    }
}
