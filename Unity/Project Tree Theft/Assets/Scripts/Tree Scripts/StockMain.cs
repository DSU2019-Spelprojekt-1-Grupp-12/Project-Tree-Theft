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
    [HideInInspector] public int numberOfPlayersAttached = 0;

    float calcMoveSpeed;
    #endregion

    #region Core functions
    void Start()
    {

    }
    void Update()
    {
        moveLog();
        unlockLog();
    }
    #endregion

    #region Functions
    void moveLog()
    {
        if (numberOfPlayersAttached < 2)
        {
            calcMoveSpeed = 0;
        }
        else
        {
            calcMoveSpeed = moveSpeed;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = moveVector * calcMoveSpeed;
        moveVector.x = 0;
        moveVector.y = 0;
    }
    void unlockLog()
    {
        if (numberOfPlayersAttached == 2)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    #endregion

}
