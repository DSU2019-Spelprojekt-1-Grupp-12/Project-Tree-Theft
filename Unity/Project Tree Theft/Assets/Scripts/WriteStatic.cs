using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteStatic : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = StaticData.currentScore;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
