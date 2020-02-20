﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    [SerializeField] int myPlayerNumber;
    private GameObject myPlayer;
    private int myNumber;

    private Color defaultColor;
    private Vector4 hitColor = new Vector4(157f/255f, 190f/255f, 0f/255f, 255f/255f);

    private void Awake(){
        PlayerMain[] players = FindObjectsOfType<PlayerMain>();
        for (int n = 0; n < players.Length; n++)
            if (players[n].GetPlayerNumber() == myPlayerNumber)
                myPlayer = players[n].gameObject;
        myNumber = myPlayer.GetComponent<PlayerMain>().GetPlayerNumber();
        Debug.Log("Player" + myPlayer.GetComponent<PlayerMain>().GetPlayerNumber() + " is bound to Slider" + myNumber);
        defaultColor = GetComponentInChildren<SliderFiller>().GetColor();
    }

    private void GetFillAreaColor(){
        var color = gameObject.GetComponentInChildren<SliderBackground>().GetColor();
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        var playerTool = myPlayer.GetComponentInChildren<PlayerTool>();
        var filler = GetComponentInChildren<SliderFiller>();
        GetComponent<Slider>().value = playerTool.GetChargeLevel();
        if (playerTool.GetChargeLevel() > playerTool.GetSweetSpot())
            filler.SetColor(hitColor);
        else
            filler.SetColor(defaultColor);        
    }
}
