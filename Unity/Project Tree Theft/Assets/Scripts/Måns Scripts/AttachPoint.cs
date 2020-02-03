using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPoint : MonoBehaviour
{
    #region Components
    public GameObject log;

    GameObject attachedPlayer = null;
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
    #endregion

    #region Functions
    public void attachToPlayer(GameObject player)
    {
        attachedPlayer = player;
    }
    public void detachFromPlayer()
    {
        attachedPlayer = null;
    }
    public void moveLogVertical(string direction)
    {
        if (direction == "up")
        {
            log.GetComponent<StockMain>().moveVector.y = 1;
        }
        else
        {
            log.GetComponent<StockMain>().moveVector.y = -1;
        }
    }
    public void moveLogHorizontal(string direction)
    {
        if (direction == "right")
        {

        }
        else
        {

        }

    }
    #endregion
}
