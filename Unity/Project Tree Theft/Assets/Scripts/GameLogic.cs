using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameLogic : MonoBehaviour
{



    public int logsToWin;
    static private int collectedLogs;



    public float timer;
    public Text timerText;

    



    [SerializeField] int levelNumber;
    //[SerializeField] GameObject menuManager;
    //[SerializeField] MenuManager _menuManager;

    

    // Start is called before the first frame update
    void Start()
    {
        //menuManager = FindObjectOfType<MenuManager>().gameObject;
        //_menuManager = menuManager.GetComponent<MenuManager>();
        StaticData.CurrentLevel = levelNumber;
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
            StaticData.Score = StaticData.Score + collectedLogs + (int)timer;
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
    public static void ResetLogs()
    {
        collectedLogs = 0;
    }

}
