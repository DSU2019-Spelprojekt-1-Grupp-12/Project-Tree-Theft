using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPoint : MonoBehaviour
{
    #region Components
    public GameObject log;

    StockMain logMain;
    GameObject attachedPlayer = null;
    #endregion

    #region Variables

    #endregion

    #region Core Functions
    void Start()
    {
        initializeAttachPoint();
    }
    void Update()
    {
        syncPlayerLocation();
    }
    #endregion

    #region Functions
    void initializeAttachPoint()
    {
        logMain = log.GetComponent<StockMain>();
    }
    public void attachToPlayer(GameObject player)
    {
        attachedPlayer = player;
        logMain.numberOfPlayersAttached++;
    }
    public void detachFromPlayer()
    {
        Debug.Log("LEAVE");
        attachedPlayer = null;
        logMain.numberOfPlayersAttached--;
    }
    public void moveLogVertical(string direction)
    {
        logMain.moveVector.y = 1;
        if (direction == "up")
        {
            logMain.moveVector.y = 1;
        }
        else
        {
            logMain.moveVector.y = -1;
        }
    }
    public void moveLogHorizontal(string direction)
    {
        if (direction == "right")
        {
            logMain.moveVector.x = 1;
        }
        else
        {
            logMain.moveVector.x = -1;
        }

    }

    void syncPlayerLocation()
    {
        if (attachedPlayer != null)
        {
            attachedPlayer.transform.position = gameObject.transform.position;
        }
    }
    #endregion
}
