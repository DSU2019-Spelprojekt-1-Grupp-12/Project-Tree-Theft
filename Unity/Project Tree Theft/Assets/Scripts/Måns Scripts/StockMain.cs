using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockMain : MonoBehaviour
{
    #region Components

    #endregion

    #region Variables
    public float moveSpeed;
    [HideInInspector] public Vector2 moveVector;
    int numberOfPlayersAttached = 0;
    #endregion

    #region Core functions
    void Start()
    {

    }
    void Update()
    {
        moveLog();
    }
    #endregion

    #region Functions
    void moveLog()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = moveVector * moveSpeed;
        moveVector.x = 0;
        moveVector.y = 0;
    }

    #endregion

}
