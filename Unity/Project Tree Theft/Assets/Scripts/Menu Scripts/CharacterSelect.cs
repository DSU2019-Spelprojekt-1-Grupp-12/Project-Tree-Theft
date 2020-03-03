using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CharacterSelect : MonoBehaviour
{

    public GameObject char1 = null;
    public GameObject char2 = null;
    public GameObject char3 = null;
    public GameObject char4 = null;


    private int p1Selected = 1;
    private int p2Selected = 2;
    public GameObject p1SelectionGraphic = null;
    public GameObject p2SelectionGraphic = null;

    public Vector2 char1Pos;
    public Vector2 char2Pos;
    public Vector2 char3Pos;
    public Vector2 char4Pos;


    PlayerControls _player1Controls;
    PlayerControls _player2Controls;

    // Start is called before the first frame update
    void Start()
    {

        
    }


    private void Awake()
    {
        _player1Controls = new PlayerControls();
        _player2Controls = new PlayerControls();
    }
    private void OnEnable()
    {
        _player1Controls.Enable();
        _player2Controls.Enable();
        _player1Controls.P1Menu.Right.performed += Next1;
        _player2Controls.P2Menu.Right.performed += Next2;
        //fill in here

    }

    private void OnDisable()
    {
        //fill in here
        _player1Controls.P1Menu.Right.performed -= Next1;
        _player2Controls.P2Menu.Right.performed -= Next2;
        _player1Controls.Disable();
        _player2Controls.Disable();
    }


    // Update is called once per frame
    void Update()
    {


        
    }




    void SetPosition(int player)
    {
        int selected = 0;
        Vector2 newPosition = Vector2.zero;
        if (player == 1)
        {
            selected = p1Selected;
        }
        else if (player == 2)
        {
            selected = p2Selected;
        }
        if (selected == 1)
        {
            newPosition = char1Pos;
        }
        else if (selected == 2)
        {
            newPosition = char2Pos;
        }
        else if (selected == 3)
        {
            newPosition = char3Pos;
        }
        else if (selected == 4)
        {
            newPosition = char4Pos;
        }
        if (player == 1)
        {
            p1SelectionGraphic.transform.position = newPosition;
        }
        else if (player == 2)
        {
            p2SelectionGraphic.transform.position = newPosition;
        }


    }
    private void Next1(InputAction.CallbackContext obj)
    {
        NextChar(1);
    }
    private void Next2(InputAction.CallbackContext obj)
    {
        NextChar(2);
    }
    void NextChar(int player)
    {

        int selected = 0;
        int otherSelected = 0;
        if (player == 1)
        {
            selected = p1Selected;
            otherSelected = p2Selected;
        }
        else if(player == 2)
        {
            selected = p2Selected;
            otherSelected = p1Selected;
        }
        selected++;
        if (selected > 4)
        {
            selected = 1;
        }
        if (selected == otherSelected)
        {
            selected++;
        }
        if (selected > 4)
        {
            selected = 1;
        }
        if (player == 1)
        {
            p1Selected = selected;
        }
        else if (player == 2)
        {
            p2Selected = selected;
        }
        SetPosition(player);
    }



    void SetPlayer1Character(GameObject selectedChar)
    {
        selectedChar.GetComponent<PlayerMain>().SetPlayerNumber(1);
        StaticData.P1Char = selectedChar;
    }
    void SetPlayer2Character(GameObject selectedChar)
    {

        if (selectedChar != StaticData.P1Char)
        {
            selectedChar.GetComponent<PlayerMain>().SetPlayerNumber(2);
            StaticData.P2Char = selectedChar;
        }
    }

}
