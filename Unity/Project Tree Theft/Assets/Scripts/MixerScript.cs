using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(BoxCollider2D))]
public class MixerScript : MonoBehaviour
{
    public AudioMixerSnapshot snapshotToPlay;
    public float snapshotFadetime;

    private void OnTriggerEnter2D()
    {
        if (snapshotToPlay != null)
            snapshotToPlay.TransitionTo(snapshotFadetime);
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        col.enabled = false;
    }
}