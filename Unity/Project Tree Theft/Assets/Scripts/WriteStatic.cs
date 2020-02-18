using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteStatic : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ("score:" + StaticData.PlayerScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
