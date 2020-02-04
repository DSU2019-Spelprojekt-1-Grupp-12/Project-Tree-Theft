using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZoneMain : MonoBehaviour
{
    #region Components

    #endregion

    #region Variables

    #endregion

    #region Core Functions
    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            GameLogic.AddLog();
            Debug.Log("LogAdded");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            GameLogic.RemoveLog();
            Debug.Log("LogRemoved");
        }
    }
    #endregion

    #region Functions

    #endregion

}
