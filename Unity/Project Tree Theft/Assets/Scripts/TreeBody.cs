using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBody : MonoBehaviour
{
    private TreeMain tree;
    
    void Awake(){
        tree = GetComponentInParent<TreeMain>();
    }

    [HideInInspector] public TreeMain GetTreeMain(){ return tree; }
}
