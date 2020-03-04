using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{

    public Vector2 p1SpawnPoint;
    public Vector2 p2SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void Awake()
    {
        Instantiate(StaticData.P1Char, p1SpawnPoint, Quaternion.identity);
        Instantiate(StaticData.P2Char, p2SpawnPoint, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
