using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWay : MonoBehaviour
{
    public float speed = 2;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Log")){
            other.gameObject.GetComponent<StockMain>().SetFloatingSpeed(speed);
            other.gameObject.GetComponent<StockMain>().SetOnWater(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Log")){
            other.gameObject.GetComponent<StockMain>().SetFloatingSpeed(0);
            other.gameObject.GetComponent<StockMain>().SetOnWater(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
