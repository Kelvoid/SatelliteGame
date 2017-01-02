using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class StarController : MonoBehaviour {

    ParticleSystem stars;
    

	void Start ()
    {
        stars = gameObject.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var starsNoise = stars.noise;
            starsNoise.enabled = !starsNoise.enabled;
        }
	}
}
