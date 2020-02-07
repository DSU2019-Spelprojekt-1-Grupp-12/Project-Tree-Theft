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
    Vector3 headingPlayerOne;
    Vector3 headingPlayerTwo;
    Vector3 facing;
    #endregion

    #region Core Functions
    void Start()
    {
        initializeRanger();
    }
    void Update()
    {
        testDirectionFind();
    }
    #endregion

    #region Functions
    void initializeRanger()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerOne = players[0];
        playerTwo = players[1];
    }
    void testDirectionFind()
    {
        facing.x = transform.rotation.x;
        facing.y = transform.rotation.y;
        facing.z = 0;
        transform.LookAt(facing);
        transform.Rotate(new Vector3(-transform.rotation.eulerAngles.x, -transform.rotation.eulerAngles.y,0f));
    }

    #endregion

}
