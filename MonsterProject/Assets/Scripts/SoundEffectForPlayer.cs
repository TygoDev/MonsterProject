using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEffectForPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    
    [Header("Button audio")]
    [SerializeField] AudioClip buttonPress;
    [SerializeField] AudioClip buttonRelease;

    private void Awake()
    {
        buttonPress.LoadAudioData();
        buttonRelease.LoadAudioData();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.T_Button))
        {
            audioSource.clip = buttonPress;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(Tags.T_Button))
        {
            audioSource.clip = buttonRelease;
            audioSource.Play();
        }
    }
}
