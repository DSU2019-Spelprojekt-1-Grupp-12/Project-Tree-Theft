using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMain : MonoBehaviour
{
    [SerializeField] GameObject logPrefab;
    [SerializeField] int hitPoints = 20;
    private TreeBody myBody;

    private void Awake(){
        myBody = GetComponentInChildren<TreeBody>();
    }

    void Start(){
        //Test();        
    }

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

    [HideInInspector] public TreeBody GetTreeBody() { return myBody; }

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
}
