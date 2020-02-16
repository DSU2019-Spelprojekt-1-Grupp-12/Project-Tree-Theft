using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Main Menu related")]
    [Rename("Splash Screen")]
    [SerializeField] private string s_Splash = "SplashScreen";
    [Rename("Main Menu")]
    [SerializeField] private string s_Main = "MainMenu";
    [Rename("Options")]
    [SerializeField] private string s_Opt = "Options";
    [Rename("New Game")]
    [SerializeField] private string s_New = "NewGame";
    [Rename("Load Game")]
    [SerializeField] private string s_Load = "LoadGame";
    [Rename("Credits")]
    [SerializeField] private string s_Credits = "Credits";

    [Header("In-Game related")]
    [Rename("Game Over Win")]
    [SerializeField] private string s_GOWin = "GameOverWin";
    [Rename("Game Over Lose")]
    [SerializeField] private string s_GOlose = "GameOverLoss";
    
    private string s_LoadLevel_n = "Level";

    private void Update(){}

    [HideInInspector] public void Load(string name){
        SceneManager.LoadScene(name);
        Debug.Log("Loaded " + name);
    }

    public void SplashScreen() { Load(s_Splash); }
    public void NewGame() { Load(s_New); }
    public void LoadGame() { Load(s_Load); }
    public void Options() { Load(s_Opt); }
    public void Credits() { Load(s_Credits); }
    public void MainMenu() { Load(s_Main); }    
    public void LoadGameOverWin() { Load(s_GOWin); }
    public void LoadGameOverLose() { Load(s_GOlose); }

    public void LoadLevel(int levelNumber){
        s_LoadLevel_n += levelNumber;
        SceneManager.LoadScene(s_LoadLevel_n);
    }
    
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Game is shutdown!");
    }
}
