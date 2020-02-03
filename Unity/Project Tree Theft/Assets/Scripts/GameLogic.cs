using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{




    static private int collectedLogs;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public static void GameOverLose()
    {
        Debug.Log("Hit");
        //SceneManager.LoadScene("GameOver");
    }

    public static void GameOverWin()
    {
        Debug.Log("Hit");
        //SceneManager.LoadScene("Victory");
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
