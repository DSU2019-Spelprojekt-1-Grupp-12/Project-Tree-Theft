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
    private readonly float horizontalAngle = 90f;


    #endregion

    #region Core functions
    private void Awake(){

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

    private void RotateHorizontal(){
        transform.rotation = Quaternion.Euler(0f, 0f, horizontalAngle);
        horizontal = true;
    }
    private void RotateVertical(){
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        horizontal = false;
    }

    public void RotateLog(int playerNumber){
        if(playerNumber == 1 && horizontal){
            RotateVertical();
            Debug.Log("Rotate Vertical");
        }
        if(playerNumber == 2 && !horizontal){
            RotateHorizontal();
            Debug.Log("Rotate Horizontal");
        }
    }

    #endregion

}
