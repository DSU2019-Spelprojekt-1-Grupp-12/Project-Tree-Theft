using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCenterPoint : MonoBehaviour
{    
    private GameObject player1;
    private GameObject player2;

    //public for debugging
    [SerializeField] private float playerDistance;

    private void Awake(){
        PlayerMain[] playersList = FindObjectsOfType<PlayerMain>();
        SetPlayers(playersList);
    }

    private void SetPlayers(PlayerMain[] playerList){
        if (playerList[0].GetPlayerNumber() == 1){
            player1 = playerList[0].gameObject;
            player2 = playerList[1].gameObject;
        } else {
            player1 = playerList[1].gameObject;
            player2 = playerList[0].gameObject;
        }        
    }
    private void Start(){ UpdatePosition(); }

    private void Update(){ UpdatePosition(); }   

    private void UpdatePosition(){
        Vector2 player1Position = player1.transform.position;
        Vector2 player2Position = player2.transform.position;

        SetNewPosition(player1Position, player2Position);
        SetDistance(player1Position, player2Position);
    }

    private void SetNewPosition(Vector2 player1Position, Vector2 player2Position){
        Vector2 newPosition = player1Position / 2 + player2Position / 2;
        gameObject.transform.position = newPosition;        
    }

    private void SetDistance(Vector2 player1Position, Vector2 player2Position){
        playerDistance = Vector2.Distance(player1Position, player2Position);
    }

    public float GetDistance() { return playerDistance; }
}
