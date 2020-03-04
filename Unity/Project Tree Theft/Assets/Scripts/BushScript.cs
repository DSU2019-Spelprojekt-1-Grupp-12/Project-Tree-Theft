using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushScript : MonoBehaviour
{
    #region Components
    Animator anim;
    AudioSource audi;
    #endregion

    #region Variables
    public float animTime;

    bool triggered = false;
    float timer;
    #endregion

    #region Core Functions
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audi = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Time.time > timer)
        {
            timer = 0;
            anim.Play("idle");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.GetComponent<RangerMain>() != null)
        {
            anim.SetTrigger("Interact");
            audi.Play();
            timer = Time.time + animTime;
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.GetComponent<RangerMain>() != null)
        {
            anim.SetTrigger("Interact");
            audi.Play();
            timer = Time.time + animTime;
        }
    }

    #endregion

    #region Functions

    #endregion

}
