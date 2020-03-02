using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundAndAnimation : MonoBehaviour
{
    #region Components
    [SerializeField] AudioClip cutGood;
    [SerializeField] AudioClip cutBetter;
    [SerializeField] AudioClip cutBest;
    [SerializeField] AudioClip charge;
    [SerializeField] AudioClip rotation;


    AudioSource audio;
    Animator animator;
    #endregion

    #region Variables

    #endregion

    #region Core Functions
    void Start()
    {
        initializePlayerSound();
    }
    //void Update()
    //{

    //}
    #endregion

    #region Functions
    void initializePlayerSound()
    {
        audio = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
    }
    void playCutSound(int cutTier)
    {
        switch (cutTier)
        {
            case 1:
                audio.clip = cutGood;
                break;
            case 2:
                audio.clip = cutBetter;
                break;
            case 3:
                audio.clip = cutBest;
                break;
        }
        audio.Play();
    }
    void playChargeSound()
    {
        audio.clip = charge;
        audio.Play();
    }
    void playRotationSound()
    {
        audio.clip = rotation;
        audio.Play();
    }
    void toggleWalkingDown(bool walking)
    {
        if (walking == false)
        {
            animator.SetBool("WalkingDown", false);
        }
        if (walking == true)
        {
            animator.SetBool("WalkingDown", true);
        }
    }

    #endregion

}
