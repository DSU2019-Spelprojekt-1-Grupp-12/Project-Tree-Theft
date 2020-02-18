using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    [SerializeField] int myPlayerNumber;
    private GameObject myPlayer;
    private int myNumber;

    private void Awake(){
        PlayerMain[] players = FindObjectsOfType<PlayerMain>();
        for (int n = 0; n < players.Length; n++)
            if (players[n].GetPlayerNumber() == myPlayerNumber)
                myPlayer = players[n].gameObject;
        myNumber = myPlayer.GetComponent<PlayerMain>().GetPlayerNumber();
        Debug.Log("Player" + myPlayer.GetComponent<PlayerMain>().GetPlayerNumber() + " is bound to Slider" + myNumber);
        //slider = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        GetComponent<Slider>().value = myPlayer.GetComponentInChildren<PlayerTool>().GetChargeLevel();
    }
}
