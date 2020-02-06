using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerMain : MonoBehaviour
{
    #region Components

    #endregion

    #region Variables

    GameObject[] players;
    GameObject playerOne;
    GameObject playerTwo;
    #endregion

    #region Core Functions
    void Start()
    {
        initializeRanger();
    }
    void Update()
    {

    }
    #endregion

    #region Functions
    void initializeRanger()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerOne = players[0];
        playerTwo = players[1];
    }

    #endregion

}
