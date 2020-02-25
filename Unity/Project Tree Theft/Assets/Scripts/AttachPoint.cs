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

    [Header("Debug Purpose, don't mess!")]
    [SerializeField] string getName = "";

    #endregion

    #region Core Functions

    private void Awake(){
        getName = gameObject.name.ToString();
    }

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
        if (!logMain.GetHorizontalAlignment()){
            if (getName == "AttachPointOne")
                attachedPlayer.GetComponent<PlayerMain>().SetDirectionSprite(2);
            else if (getName == "AttachPointTwo")
                attachedPlayer.GetComponent<PlayerMain>().SetDirectionSprite(0);
        }
        else if (logMain.GetHorizontalAlignment()){
            if (getName == "AttachPointOne")
                attachedPlayer.GetComponent<PlayerMain>().SetDirectionSprite(3);
            else if (getName == "AttachPointTwo")
                attachedPlayer.GetComponent<PlayerMain>().SetDirectionSprite(1);
        }
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

    [HideInInspector] public GameObject GetAttachedPlayer() { return attachedPlayer; }
    #endregion
}
