using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{


    public GameObject gameLogic;
    public GameObject canvas;
    public GameObject canvas2;
    private bool cutSceneDone = false;

    private float introTimer;
    public float introEndtime;
    //private bool introOver;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        gameLogic.SetActive(false);
        canvas2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (cutSceneDone == false)
        {
            introTimer += Time.deltaTime;
        }
            

        if (introTimer > introEndtime)
        {
            gameLogic.SetActive(true);
            canvas.SetActive(true);
            canvas2.SetActive(true);
        }
      

    }
}
