using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    private AudioSource MyUIAudioSource;

    public AudioClip AudioBePlay;
    private void Awake()
    {
        Initialized_me();
    }
    private void Initialized_me()
    {
        MyUIAudioSource= GetComponent<AudioSource>();
        FD_UI_Debugstate.FD_Debugging+= PlayUISound;

    }

    public void PlayUISound()
    {
        MyUIAudioSource.clip= AudioBePlay;
        MyUIAudioSource.Play();
    }

}
