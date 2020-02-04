using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{



    public int logsToWin;
    static private int collectedLogs;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
