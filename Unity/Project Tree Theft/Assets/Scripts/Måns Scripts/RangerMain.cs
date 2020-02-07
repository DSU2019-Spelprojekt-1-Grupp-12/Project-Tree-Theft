using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerMain : MonoBehaviour
{
    #region Components

    GuardPatrol pathingScript;
    #endregion

    #region Variables
    public float chaseRange;
    public float chaseSpeed;

    GameObject[] players;
    GameObject playerOne;
    GameObject playerTwo;
    Vector3 headingPlayerOne;
    Vector3 headingPlayerTwo;
    bool chasing = false; 
    #endregion

    #region Core Functions
    void Start()
    {
        InitializeRanger();
    }
    void Update()
    {
        //DirectionFind();
        Chase();
        TogglePathing();
    }
    #endregion

    #region Functions
    void InitializeRanger()
    {
        pathingScript = gameObject.GetComponent<GuardPatrol>();
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
            DirectionFind();
            transform.position += headingPlayerOne.normalized * chaseSpeed;
        }
        if(headingPlayerTwo.magnitude < headingPlayerOne.magnitude && headingPlayerTwo.magnitude < chaseRange)
        {
            DirectionFind();
            transform.position += headingPlayerTwo.normalized * chaseSpeed;
        }

        if (headingPlayerOne.magnitude < chaseRange || headingPlayerTwo.magnitude < chaseRange)
        {
            chasing = true;
        }
        else
        {
            chasing = false;
        }
    }
    void TogglePathing()
    {
        if (chasing)
        {
            pathingScript.SetSpeed(0);
            pathingScript.active = false;
            //pathingScript.speed = 0;
            Debug.Log("chaseon");
        }
        else
        {
            pathingScript.SetSpeed(pathingScript.GetOriginalSpeed());
            pathingScript.active = true;
            //pathingScript.speed = 0;
            Debug.Log("chaseoff");
        }
    }

    #endregion

}
