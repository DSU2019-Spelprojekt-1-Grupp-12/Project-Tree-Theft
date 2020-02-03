using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMain : MonoBehaviour
{
    #region Components
    public Sprite stump;
    public Sprite log;

    SpriteRenderer spriteRendererComponent;
    #endregion

    #region Variables
    public int hitPoints;


    #endregion

    #region Core Functions
    void Start()
    {
        initializeTreeMain();
    }
    void Update()
    {

    }
    #endregion

    #region Functions
    void initializeTreeMain()
    {
        spriteRendererComponent = gameObject.GetComponent<SpriteRenderer>();
    }

    #endregion
}
