using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    NavMeshAgent agent;
    #endregion

    #region Variables
    public float chaseRange;
    public float chaseSpeed;
    public float spriteUpDownTolerance;
    public float chaseStopRange;

    Vector3 destination;
    GameObject[] players;
    GameObject playerOne;
    GameObject playerTwo;
    Vector2 headingPlayerOne;
    Vector2 headingPlayerTwo;
    Vector2 movementDirection;
    bool spriteOrientationDone = false;
    bool chaseStopped = false;
    bool returning = false;
    bool playerOneObstructed = false;
    bool playerTwoObstructed = false;
    bool alertSoundPlayed = false;
    Vector3 agentVelocity;
    Vector3 previousPosition;
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
        SpriteOrientation();
        CheckObstruction();
    }
    private void OnTriggerEnter2D(Collider2D other)
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

        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.Warp(transform.position);
        agent.SetDestination(gameObject.GetComponent<GuardPatrol>().currentCheckpoint.transform.position);
        agent.speed = chaseSpeed;
    }
    void DirectionFind()
    {
        headingPlayerOne = playerOne.transform.position - gameObject.transform.position;
        headingPlayerTwo = playerTwo.transform.position - gameObject.transform.position;
    }
    void Chase()
    {
        DirectionFind();
        if (headingPlayerOne.magnitude < headingPlayerTwo.magnitude && headingPlayerOne.magnitude < chaseRange && playerOneObstructed == false)
        {
            DirectionFind();
            agent.SetDestination(new Vector3 (playerOne.transform.position.x, playerOne.transform.position.y, 0f));
            chaseStopped = false;
        }
        if(headingPlayerTwo.magnitude < headingPlayerOne.magnitude && headingPlayerTwo.magnitude < chaseRange && playerTwoObstructed == false)
        {
            DirectionFind();
            agent.SetDestination(new Vector3(playerTwo.transform.position.x, playerTwo.transform.position.y, 0f));
            chaseStopped = false;
        }
        if (headingPlayerTwo.magnitude < chaseRange && playerTwoObstructed == false && alertSoundPlayed == false  || headingPlayerOne.magnitude < chaseRange && playerOneObstructed == false && alertSoundPlayed == false)
        {
            gameObject.GetComponent<AudioSource>().Play();
            alertSoundPlayed = true;
        }
        if (headingPlayerTwo.magnitude < chaseRange && playerTwoObstructed == false|| headingPlayerOne.magnitude < headingPlayerTwo.magnitude && headingPlayerOne.magnitude < chaseRange && playerOneObstructed == false)
        {

        }
    }
    void TogglePatrolPathing()
    {
        if (chaseStopped == false)
        {
            pathingScript.active = false;
        }
        else
        {
            pathingScript.active = true;
        }
        if ((agent.destination - agent.transform.position).magnitude <= chaseStopRange && headingPlayerOne.magnitude > chaseRange && headingPlayerTwo.magnitude > chaseRange && chaseStopped == false)
        {
            agent.SetDestination(gameObject.GetComponent<GuardPatrol>().currentCheckpoint.transform.position);
            chaseStopped = true;
            returning = true;

        }
        if ((agent.destination - agent.transform.position).magnitude <= chaseStopRange && headingPlayerOne.magnitude > chaseRange && headingPlayerTwo.magnitude > chaseRange && chaseStopped == true)
        {
            agent.ResetPath();
            returning = false;
        }
    }
    void SpriteOrientation()
    {
        spriteOrientationDone = false;
        if (chaseStopped == false || returning == true)
        {
            movementDirection = agent.desiredVelocity.normalized;
        }
        else
        {
            movementDirection = rb.velocity.normalized;
        }

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
    void CheckObstruction()
    {
        RaycastHit2D playerOneHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), headingPlayerOne);
        RaycastHit2D playerTwoHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), headingPlayerTwo);
        if (playerOneHit.collider != null)
        {
            Debug.Log("Empty");
        }
        {

        }

        if (playerOneHit.collider != null && playerOneHit.collider.CompareTag("Wall"))
        {
            playerOneObstructed = true;
        }
        else
        {
            playerOneObstructed = false;
        }
        if (playerTwoHit.collider != null && playerTwoHit.collider.CompareTag("Wall"))
        {
            playerTwoObstructed = true;
        }
        else
        {
            playerTwoObstructed = false;
        }
    }
    #endregion

}
