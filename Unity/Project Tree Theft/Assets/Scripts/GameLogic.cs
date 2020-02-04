using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{



    public int logsToWin;
    static private int collectedLogs;



    public float timer;
    public Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        timerText.text = string.Format("{00}", timer);


        //Victory and Lose Conditions
        if (timer <= 0)
        {
            GameOverLose();
        }
        if (collectedLogs >= logsToWin)
        {
            GameOverWin();
        }


    }






    public static void GameOverLose()
    {
        SceneManager.LoadScene("GameOverLoss");
    }

    public static void GameOverWin()
    {
        SceneManager.LoadScene("GameOverWin");
    }
    public static void AddLog()
    {
        collectedLogs++;
    }
    public static void RemoveLog()
    {
        collectedLogs--;
    }
}
