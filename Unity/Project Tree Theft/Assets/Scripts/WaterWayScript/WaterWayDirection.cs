using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWayDirection : MonoBehaviour
{

    public int directionIndex = 0;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Log")){
            other.gameObject.GetComponent<StockMain>().SetDirectionIndex(directionIndex);
        }
    }

    void Start(){
        
    }

    
    void Update(){
        
    }
}
