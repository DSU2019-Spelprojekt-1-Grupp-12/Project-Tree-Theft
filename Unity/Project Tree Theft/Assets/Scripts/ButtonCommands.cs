using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCommands : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void TestLevel1()
    {
        GameLogic.ResetLogs();
        SceneManager.LoadScene("MasterSandbox");
    }
    public void TestWin()
    {
        SceneManager.LoadScene("GameOverWin");
    }
    public void TestLoss()
    {
        SceneManager.LoadScene("GameOverLoss");
    }
}
