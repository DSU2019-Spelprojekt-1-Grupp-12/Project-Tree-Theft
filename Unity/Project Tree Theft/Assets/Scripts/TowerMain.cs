using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMain : MonoBehaviour
{




    //Rotation  (Rotate This One)
    public Rigidbody2D sightArea;

    public PolygonCollider2D sight;



  
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        sightArea.transform.Rotate(0, 0, 1);
        
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            
            GameLogic.GameOverLose();
        }
    }
}
