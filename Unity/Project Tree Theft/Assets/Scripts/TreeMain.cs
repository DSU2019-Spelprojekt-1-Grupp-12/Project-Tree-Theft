using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMain : MonoBehaviour
{
    [SerializeField] GameObject logPrefab;
    [SerializeField] int hitPoints = 20;    

    // Start is called before the first frame update
    void Start(){
        //Test();
    }

    // Update is called once per frame
    void Update(){
        Chopped();
    }

    [HideInInspector] public void SetDamage(int damage){ hitPoints -= damage; }
    public int GetHitPoints() { return hitPoints; }

    private void Chopped() {
        if(hitPoints < 1){
            Instantiate(logPrefab,gameObject.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

    //Function for testing
    //private void Test(){
    //    StartCoroutine(TestDecreasingHealth());
    //}

    //Coroutine for testing
    //IEnumerator TestDecreasingHealth(){
    //    var i = 0;
    //    while (i < 11){
    //        i++;
    //        yield return new WaitForSecondsRealtime(1f);
    //        SetDamage(2);
    //    }
    //}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tools"))
        {
            var damage = FindObjectOfType<PlayerTool>().GetDamage();
            SetDamage(damage);
            Debug.Log("Tree Hit");
        }
        else
        {
            Debug.Log("Tree Not Hit");
        }
    }
}
