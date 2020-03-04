using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{

    public GameObject[] levels;
    public int currentSelectLevel;
    // Start is called before the first frame update
    void Start()
    {
        //levels = new GameObject[StaticData.ClearedLevels];

        //for (int i = 0; levels.Length < StaticData.ClearedLevels || levels.Length == 1;i++)
        //{
        //    levels[i] = GameObject.Find("Level1");
        //}

        for (int i = 0; i != levels.Length; i++)
        {
            levels[i].SetActive(false);
        }

        levels[currentSelectLevel].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextSelect()
    {
        Debug.Log("Pressed");
        levels[currentSelectLevel].SetActive(false);
        currentSelectLevel++;
        if (currentSelectLevel == levels.Length || currentSelectLevel > StaticData.ClearedLevels)
        {
            currentSelectLevel = 0;
        }
        levels[currentSelectLevel].SetActive(true);
    }
    public void PreviousSelect()
    {
        Debug.Log("Pressed");
        levels[currentSelectLevel].SetActive(false);
        currentSelectLevel--;
        if (currentSelectLevel < 0)
        {
            currentSelectLevel = StaticData.ClearedLevels - 1;
            if (currentSelectLevel < 0)
            {
                currentSelectLevel = 0;
            }
        }
        levels[currentSelectLevel].SetActive(true);
    }
    public void Select()
    {
        StaticData.CurrentLevel = currentSelectLevel;
    }


}
