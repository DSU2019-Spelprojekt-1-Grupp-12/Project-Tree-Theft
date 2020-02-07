using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerMain : MonoBehaviour
{
    #region Components

    #endregion

    #region Variables
    public float chaseRange;
    public float chaseSpeed;

    GameObject[] players;
    GameObject playerOne;
    GameObject playerTwo;
    Vector3 headingPlayerOne;
    Vector3 headingPlayerTwo;
    #endregion

    #region Core Functions
    void Start()
    {
        initializeRanger();
    }
    void Update()
    {
        DirectionFind();
        Chase();
    }
    #endregion

    #region Functions
    void initializeRanger()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerOne = players[0];
        playerTwo = players[1];
    }
    void DirectionFind()
    {
        headingPlayerOne = playerOne.transform.position - gameObject.transform.position;
        headingPlayerTwo = playerTwo.transform.position - gameObject.transform.position;
        if (headingPlayerOne.magnitude > headingPlayerTwo.magnitude)
        {
            transform.right = playerTwo.transform.position - gameObject.transform.position;
        }
        else
        {
            transform.right = playerOne.transform.position - gameObject.transform.position;
        }
    }
    void Chase()
    {
        headingPlayerOne = playerOne.transform.position - gameObject.transform.position;
        headingPlayerTwo = playerTwo.transform.position - gameObject.transform.position;
        if (headingPlayerOne.magnitude < headingPlayerTwo.magnitude && headingPlayerOne.magnitude < chaseRange)
        {
            transform.position += headingPlayerOne.normalized * chaseSpeed;
        }
        if(headingPlayerTwo.magnitude < headingPlayerOne.magnitude && headingPlayerTwo.magnitude < chaseRange)
        {
            transform.position += headingPlayerTwo.normalized * chaseSpeed;
        }
    }

    #endregion

}
