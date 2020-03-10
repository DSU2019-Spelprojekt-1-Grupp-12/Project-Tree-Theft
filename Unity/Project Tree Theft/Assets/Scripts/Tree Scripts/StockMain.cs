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

    public float floatingSpeed = 0f;
    public int directionIndex = 0;
    public bool onWater = false;
    private Vector3 upVector = new Vector3(0f, 1f, 0f);
    private Vector3 rightVector = new Vector3(1f, 0f, 0f);
    private Vector3 downVector = new Vector3(0f, -1f, 0f);
    private Vector3 leftVector = new Vector3(0f, -1f, 0f);

    private Rigidbody2D myRigidBody;

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

    void Start(){
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveLog();
        unlockLog();
        WaterMovement();
    }
    #endregion

    #region Functions

    public bool GetHorizontalAlignment() { return horizontal; }
    public void SetFloatingSpeed(float floatingSpeed) { this.floatingSpeed = floatingSpeed; }
    public float GetFloatingSpeed() { return floatingSpeed; }
    public void SetDirectionIndex(int directionIndex) { this.directionIndex = directionIndex; }
    public int GetDirectionIndex() { return directionIndex; }
    public void SetOnWater(bool onWater) { this.onWater = onWater; }
    public bool GetOnWater() { return onWater; }
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

    private void RotateHorizontal(int directionIndex){
        if (directionIndex == (int)DirectionIndex.right)
            transform.rotation = Quaternion.Euler(0f, 0f, -horizontalAngle);
        else if (directionIndex == (int)DirectionIndex.left)
            transform.rotation = Quaternion.Euler(0f, 0f, horizontalAngle);
        horizontal = true;
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

    private void RotateVertical(int directionIndex){
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        horizontal = false;
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

    public void RotateLog(int playerNumber, float rotationSpeed){
        if (playerNumber == 1)
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
        }
        if (playerNumber == 2)
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, -rotationSpeed));
        }
        
        //GameObject player1 = p1_attachPoint.gameObject.GetComponent<AttachPoint>().GetAttachedPlayer();
        //GameObject player2 = p2_attachPoint.gameObject.GetComponent<AttachPoint>().GetAttachedPlayer();
        //int directionModifier = 1;
        //if (playerNumber == 1 && horizontal){
        //    RotateVertical(directionModifier, player1, player2);
        //    Debug.Log("Rotate Vertical");
        //}
        //if(playerNumber == 2 && !horizontal){
        //    RotateHorizontal(directionModifier, player1, player2);
        //    Debug.Log("Rotate Horizontal");
        //}


    }

    private void RotatePlayers(int directionModifier, GameObject p1, GameObject p2, int p1_directionIndex, int p2_directionIndex){
        p1.GetComponent<PlayerMain>().SetDirectionSprite(p1_directionIndex + directionModifier);
        p2.GetComponent<PlayerMain>().SetDirectionSprite(p2_directionIndex + directionModifier);
    }

    private void WaterMovement(){
        if (GetOnWater()){
            var p1 = p1_attachPoint.gameObject.GetComponent<AttachPoint>().HasPlayerAttached();
            var p2 = p2_attachPoint.gameObject.GetComponent<AttachPoint>().HasPlayerAttached();
            Debug.Log(p1);

            if (!(p1 && p2))
            {
                Debug.Log("AttachPoints are null");
                if (GetDirectionIndex() == (int)DirectionIndex.up){
                    RotateVertical(GetDirectionIndex());
                    transform.Translate(upVector * floatingSpeed * Time.deltaTime);
                }
                if (GetDirectionIndex() == (int)DirectionIndex.right){
                    RotateHorizontal(GetDirectionIndex());
                    transform.Translate(downVector * floatingSpeed * Time.deltaTime);
                }
                if (GetDirectionIndex() == (int)DirectionIndex.down){
                    RotateVertical(GetDirectionIndex());
                    transform.Translate(downVector * floatingSpeed * Time.deltaTime);
                }
                if (GetDirectionIndex() == (int)DirectionIndex.left){
                    RotateHorizontal(GetDirectionIndex());
                    transform.Translate(leftVector * floatingSpeed * Time.deltaTime);
                }
            }
        }
    }

    #endregion

}
