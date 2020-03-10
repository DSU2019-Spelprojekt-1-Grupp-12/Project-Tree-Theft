using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshMain : MonoBehaviour
{


    GameObject[] rangers;
    GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        rangers = GameObject.FindGameObjectsWithTag("Ranger");
        foreach (GameObject ranger in rangers)
        {
            Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), ranger.GetComponent<Collider2D>());
        }
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        }
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
