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
        

        for (int i = 0; i != levels.Length; i++)
        {
            levels[i].SetActive(false);
        }

        levels[currentSelectLevel].SetActive(true);

        if (Input.GetKeyDown("space"))
        {
            NextSelect();
        }
        
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
        if (currentSelectLevel == levels.Length)
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
            currentSelectLevel = levels.Length -1;
        }
        levels[currentSelectLevel].SetActive(true);
    }


}
