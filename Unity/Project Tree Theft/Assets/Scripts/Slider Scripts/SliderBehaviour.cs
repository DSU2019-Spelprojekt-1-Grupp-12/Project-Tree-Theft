﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    [SerializeField] int myPlayerNumber;
    private GameObject myPlayer;
    private int myNumber;
    private float myCharge;

    private Color defaultColor;    
    private Vector4 hitColor = new Vector4(157f/255f, 190f/255f, 0f/255f, 255f/255f);
    private Color betterHitColor = Color.blue;
    private Color bestHitColor = Color.black;

    private void Awake(){
        
    }

    private void GetFillAreaColor(){
        var color = gameObject.GetComponentInChildren<SliderBackground>().GetColor();
    }

    // Start is called before the first frame update
    void Start(){
        PlayerMain[] players = FindObjectsOfType<PlayerMain>();
        for (int n = 0; n < players.Length; n++)
            if (players[n].GetPlayerNumber() == myPlayerNumber)
                myPlayer = players[n].gameObject;
        myNumber = myPlayer.GetComponent<PlayerMain>().GetPlayerNumber();
        Debug.Log("Player" + myPlayer.GetComponent<PlayerMain>().GetPlayerNumber() + " is bound to Slider" + myNumber);
        defaultColor = gameObject.GetComponentInChildren<SliderFiller>().GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update() {
        var playerTool = myPlayer.GetComponentInChildren<PlayerTool>();
        var filler = GetComponentInChildren<SliderFiller>();
        GetComponent<Slider>().value = playerTool.GetChargeLevel();
        myCharge = GetComponent<Slider>().value;
        //if (playerTool.GetChargeLevel() > playerTool.GetSweetSpot() && playerTool.GetChargeLevel() <= playerTool.GetSweetSpot() + 20)
        //    filler.SetColor(hitColor);
        //else
        //    filler.SetColor(defaultColor);

        if (playerTool.GetChargeLevel() >= playerTool.GetSweetSpots()[0] && playerTool.GetChargeLevel() < playerTool.GetSweetSpots()[1])
            filler.SetColor(hitColor);
        else if (playerTool.GetChargeLevel() >= playerTool.GetSweetSpots()[1] && playerTool.GetChargeLevel() < playerTool.GetSweetSpots()[2])
            filler.SetColor(betterHitColor);
        else if (playerTool.GetChargeLevel() >= playerTool.GetSweetSpots()[2] && playerTool.GetChargeLevel() <= playerTool.GetMaxCharge())
            filler.SetColor(bestHitColor);
        else
            filler.SetColor(defaultColor);
    }

    public int GetCharge() { return (int) myCharge; }
    public int GetPlayerNumber() { return myPlayerNumber; }
}
