using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{

    public GameObject char1 = null;
    public GameObject char2 = null;
    public GameObject char3 = null;
    public GameObject char4 = null;


    private int p1Selected = 1;
    private int p2Selected = 2;

    public Vector2 char1Pos;
    public Vector2 char2Pos;
    public Vector2 char3Pos;
    public Vector2 char4Pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void NextChar(int player)
    {
        if (player == 1)
        {
            p1Selected++;
            if (p1Selected == p2Selected)
            {
                p1Selected++;
            }
            if (p1Selected > 4)
            {
                p1Selected = 1;
            }
        }
        else if (player == 2)
        {
            p2Selected++;
            if (p2Selected == p1Selected)
            {
                p2Selected++;
                
            }
            if (p2Selected > 4)
            {
                p2Selected = 1;
            }

        }


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
