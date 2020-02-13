using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerMain : MonoBehaviour
{
    #region Components
    public Sprite upSprite;
    public Sprite rightSprite;
    public Sprite downSprite;
    public Sprite leftSprite;

    GuardPatrol pathingScript;
    Rigidbody2D rb;
    SpriteRenderer spriteComponent;
    #endregion

    #region Variables
    public float chaseRange;
    public float chaseSpeed;
    public float spriteUpDownTolerance;

    GameObject[] players;
    GameObject playerOne;
    GameObject playerTwo;
    Vector2 headingPlayerOne;
    Vector2 headingPlayerTwo;
    Vector2 movementDirection;
    bool chasing = false;
    bool spriteOrientationDone = false;
    #endregion

    #region Core Functions
    void Start()
    {
        InitializeRanger();
    }
    void Update()
    {
        Chase();
        TogglePatrolPathing();
        spriteOrientation();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameLogic.GameOverLose();
        }
    }
    #endregion

    #region Functions
    void InitializeRanger()
    {
        pathingScript = gameObject.GetComponent<GuardPatrol>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteComponent = gameObject.GetComponent<SpriteRenderer>();
        players = GameObject.FindGameObjectsWithTag("Player");
        playerOne = players[0];
        playerTwo = players[1];
    }
    void DirectionFind()
    {
        headingPlayerOne = playerOne.transform.position - gameObject.transform.position;
        headingPlayerTwo = playerTwo.transform.position - gameObject.transform.position;
    }
    void Chase()
    {
        DirectionFind();
        if (headingPlayerOne.magnitude < headingPlayerTwo.magnitude && headingPlayerOne.magnitude < chaseRange)
        {
            DirectionFind();
            rb.velocity = headingPlayerOne.normalized * chaseSpeed;
            Debug.Log(headingPlayerOne.normalized);
        }
        if(headingPlayerTwo.magnitude < headingPlayerOne.magnitude && headingPlayerTwo.magnitude < chaseRange)
        {
            DirectionFind();
            rb.velocity = headingPlayerTwo.normalized * chaseSpeed;
            Debug.Log(headingPlayerTwo.normalized);
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
    void TogglePatrolPathing()
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
    void spriteOrientation()
    {
        spriteOrientationDone = false;
        movementDirection = rb.velocity.normalized;
        if (movementDirection.y > spriteUpDownTolerance && spriteOrientationDone == false)
        {
            spriteComponent.sprite = upSprite;
            spriteOrientationDone = true;
        }
        if (movementDirection.y < -spriteUpDownTolerance && spriteOrientationDone == false || movementDirection.x == 0 && movementDirection.y == 0)
        {
            spriteComponent.sprite = downSprite;
            spriteOrientationDone = true;
        }
        if (movementDirection.x > 0 && spriteOrientationDone == false)
        {
            spriteComponent.sprite = rightSprite;
            spriteOrientationDone = true;
        }
        if (movementDirection.x < 0 && spriteOrientationDone == false)
        {
            spriteComponent.sprite = leftSprite;
            spriteOrientationDone = true;
        }
    }


    #endregion

}
