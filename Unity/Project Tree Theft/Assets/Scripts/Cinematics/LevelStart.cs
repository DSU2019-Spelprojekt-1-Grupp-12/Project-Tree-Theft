using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{


    public GameObject cinematicCamera;
    public GameObject levelCamera;

    private float cutsceneTimer;
    //private bool introOver;
    // Start is called before the first frame update
    void Start()
    {
        levelCamera.SetActive(false);
        cinematicCamera.SetActive(true);
        //levelCamera.GetComponentInChildren<Camera>().fieldOfView = 3;
        //introOver = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (cinematicCamera.activeInHierarchy == true)
        {
            cutsceneTimer += Time.deltaTime;
            cinematicCamera.GetComponentInChildren<Camera>().fieldOfView -= 0.02f;
        }


        if (cutsceneTimer > 3.0f)
        {
            levelCamera.SetActive(true);
            cinematicCamera.SetActive(false);
        }
        //if (levelCamera.GetComponentInChildren<Camera>().fieldOfView > 1 && introOver == false)
        //{
        //    levelCamera.GetComponentInChildren<Camera>().fieldOfView -= 0.02f;
        //}
        //else if (levelCamera.GetComponentInChildren<Camera>().fieldOfView < 1)
        //{
        //    introOver = false;
        //}

    }
}
