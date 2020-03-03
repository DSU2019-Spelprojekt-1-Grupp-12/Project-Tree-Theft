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
    private bool set1;
    private int p2Selected = 2;
    private bool set2;

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
        SetPosition(1);
        SetPosition(2);
        set1 = false;
        set2 = false;
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

        _player1Controls.P1Menu.Left.performed += Prev1;
        _player2Controls.P2Menu.Left.performed += Prev2;


        _player1Controls.P1Menu.Select.performed += SetP1;
        _player2Controls.P2Menu.Select.performed += SetP2;
        //fill in here
    }

    private void OnDisable()
    {
        //fill in here
        _player1Controls.P1Menu.Right.performed -= Next1;
        _player2Controls.P2Menu.Right.performed -= Next2;

        _player1Controls.P1Menu.Left.performed -= Prev1;
        _player2Controls.P2Menu.Left.performed -= Prev2;

        _player1Controls.P1Menu.Select.performed -= SetP1;
        _player2Controls.P2Menu.Select.performed -= SetP2;

        _player1Controls.Disable();
        _player2Controls.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        if (set1 == true && set2 == true)
        {
            //Insert Scene Movement. Check the static datas current level. Then become that. Level Select Goes Here after setting currentlevel.
        }
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
        if (set1 == false)
        {
            NextChar(1, true);
        }
        
    }
    private void Next2(InputAction.CallbackContext obj)
    {
        if (set2 == false)
        {
            NextChar(2, true);
        }
            
    }
    private void Prev1(InputAction.CallbackContext obj)
    {
        if (set1 == false)
        {
            NextChar(1, false);
        }
            
    }
    private void Prev2(InputAction.CallbackContext obj)
    {
        if (set2 == false)
        {
            NextChar(2, false);
        }
            
    }
    void NextChar(int player, bool positive)
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
        if (positive)
        {
            selected++;
        }
        else if (!positive)
        {
            selected--;
        }
        
        if (selected > 4)
        {
            selected = 1;
        }
        if (selected == otherSelected)
        {
            if (positive)
            {
                selected++;
            }
            else if (!positive)
            {
                selected--;
            }
        }
        if (selected > 4)
        {
            selected = 1;
        }
        if (selected < 1)
        {
            selected = 4;
            if (selected == otherSelected)
            {
                selected--;
            }
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


    private void SetP1(InputAction.CallbackContext obj)
    {
        if (set1 == false)
        {
            set1 = true;
            if (p1Selected == 1)
            {
                SetPlayer1Character(char1);
            }
            if (p1Selected == 2)
            {
                SetPlayer1Character(char2);
            }
            if (p1Selected == 3)
            {
                SetPlayer1Character(char3);
            }
            if (p1Selected == 4)
            {
                SetPlayer1Character(char4);
            }
        }
        else
        {
            set1 = false;
        }
        
    }
    private void SetP2(InputAction.CallbackContext obj)
    {
        if (set2 == false)
        {
            set2 = true;
            if (p2Selected == 1)
            {
                SetPlayer2Character(char1);
            }
            if (p2Selected == 2)
            {
                SetPlayer2Character(char2);
            }
            if (p2Selected == 3)
            {
                SetPlayer2Character(char3);
            }
            if (p2Selected == 4)
            {
                SetPlayer2Character(char4);
            }
        }
        else
        {
            set2 = false;
        }

    }
    private void UnSetP1(InputAction.CallbackContext obj)
    {
        set1 = false;
    }
    private void UnSetP2(InputAction.CallbackContext obj)
    {
        set2 = false;
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
