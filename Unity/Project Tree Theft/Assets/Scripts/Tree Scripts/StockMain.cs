using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockMain : MonoBehaviour
{
    #region Components

    #endregion

    #region Variables
    public int pointValue;
    public float moveSpeed;
    [HideInInspector] public Vector2 moveVector;
    [HideInInspector] public int numberOfPlayersAttached = 0;

    float calcMoveSpeed;

    [SerializeField] private bool horizontal;
    private readonly float horizontalAngle = -90f;

    private AttachPoint p1_attachPoint;
    private AttachPoint p2_attachPoint;
    #endregion

    #region Core functions
    private void Awake(){
        AttachPoint[] attachPoints = GetComponentsInChildren<AttachPoint>();
        p1_attachPoint = attachPoints[0];
        p2_attachPoint = attachPoints[1];
        Debug.Log(attachPoints[0].name.ToString());
    }

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

    public bool GetHorizontalAlignment() { return horizontal; }
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

    private void RotateHorizontal(int directionModifier, GameObject p1, GameObject p2){
        var p1_directionIndex = p1.GetComponent<PlayerMain>().GetDirectionSprite();
        var p2_directionIndex = p2.GetComponent<PlayerMain>().GetDirectionSprite();
        if (p1_directionIndex >= 3)
            p1_directionIndex = -1;
        if (p2_directionIndex >= 3)
            p2_directionIndex = -1;

        transform.rotation = Quaternion.Euler(0f, 0f, horizontalAngle);
        RotatePlayers(directionModifier, p1, p2, p1_directionIndex, p2_directionIndex);
        horizontal = true;
    }
    private void RotateVertical(int directionModifier, GameObject p1, GameObject p2){
        var p1_directionIndex = p1.GetComponent<PlayerMain>().GetDirectionSprite();
        var p2_directionIndex = p2.GetComponent<PlayerMain>().GetDirectionSprite();
        if (p1_directionIndex <= 0)
            p1_directionIndex = 4;
        if (p2_directionIndex <= 0)
            p2_directionIndex = 4;

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        RotatePlayers(-directionModifier, p1, p2, p1_directionIndex, p2_directionIndex);
        horizontal = false;
    }

    public void RotateLog(int playerNumber){
        GameObject player1 = p1_attachPoint.gameObject.GetComponent<AttachPoint>().GetAttachedPlayer();
        GameObject player2 = p2_attachPoint.gameObject.GetComponent<AttachPoint>().GetAttachedPlayer();
        int directionModifier = 1;
        if (playerNumber == 1 && horizontal){
            RotateVertical(directionModifier, player1, player2);
            Debug.Log("Rotate Vertical");
        }
        if(playerNumber == 2 && !horizontal){
            RotateHorizontal(directionModifier, player1, player2);
            Debug.Log("Rotate Horizontal");
        }


    }

    private void RotatePlayers(int directionModifier, GameObject p1, GameObject p2, int p1_directionIndex, int p2_directionIndex){
        p1.GetComponent<PlayerMain>().SetDirectionSprite(p1_directionIndex + directionModifier);
        p2.GetComponent<PlayerMain>().SetDirectionSprite(p2_directionIndex + directionModifier);
    }

    #endregion

}
