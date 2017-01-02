using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutoff : MonoBehaviour
{

    float alphaCutoff;
    Material material;
    float alpha;
    public float speed;

    [Range(0,1)]
    public float target;

    string shaderValue = "_Cutoff";

    void Start ()
    {
        material = gameObject.GetComponent<Renderer>().material;
        //StartCoroutine(ChangeCutoff(speed, target));
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StopAllCoroutines();
            StartCoroutine(ChangeCutoff(speed, target));
        }
    }

    IEnumerator ChangeCutoff(float duration, float target)
    {
        float elapsed = 0;
        float start = material.GetFloat(shaderValue);
        while (elapsed < duration)
        {
            var range = target - start;
            elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);
            material.SetFloat(shaderValue, (start + range * (elapsed / duration)));
            yield return 0;
        }
        material.SetFloat(shaderValue, target);
        yield return null;
    }

}
