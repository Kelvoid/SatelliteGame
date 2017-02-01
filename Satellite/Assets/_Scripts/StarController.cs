using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class StarController : MonoBehaviour {

    GameManager gameManager;
    ParticleSystem stars;

	void Start ()
    {
        stars = gameObject.GetComponent<ParticleSystem>();
        gameManager = FindObjectOfType<GameManager>();
    }
	
	void Update ()
    {
        var starTrails = stars.trails;

        if (gameManager.stateManager.isTravelling == true)
        {
            gameObject.transform.position = gameManager.mainCamera.transform.position;           
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
