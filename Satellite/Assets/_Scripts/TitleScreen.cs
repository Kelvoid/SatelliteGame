using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{

    public Color backgroundColor;

    public Camera mainCamera;
    public GameObject backgroundSat;

    public GameObject overlay;

	void Start ()
    {
        setBackgroundColor(backgroundColor);
    }
	
	void Update ()
    {

	}

    void setBackgroundColor(Color c)
    {
        mainCamera.backgroundColor = c;
        backgroundSat.GetComponent<MeshRenderer>().material.color = c;
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(1);
    }
}
