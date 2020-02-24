using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AmbianceScript : MonoBehaviour
{
    public float minTime;
    public float maxTime;
    public AudioClip[] clips;
    private AudioSource source;
    [Range(0.1f, 3.0f)]
    public float minPitch;
    [Range(0.1f, 3.0f)]
    public float maxPitch;


    void Start()
    {
        StartCoroutine(SpawnSound());
        source = GetComponent<AudioSource>();
    }

    void PlayRandom()
    {
        source.clip = clips[Random.Range(0, clips.Length)];
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
    }
     IEnumerator SpawnSound()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        Start();
        PlayRandom();
    }
}
