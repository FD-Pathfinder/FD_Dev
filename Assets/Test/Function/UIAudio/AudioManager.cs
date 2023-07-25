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
        Mano_InputManger.IAmRelease += PlayUISound;
        Mano_InputManger.IAmTouching += PlayUISound;
        FD_Interaction.test += PlayUISound;
    }
    private void Initialized_me()
    {
        MyUIAudioSource= GetComponent<AudioSource>();
    }

    public void PlayUISound()
    {
        MyUIAudioSource.clip= AudioBePlay;
        MyUIAudioSource.Play();
    }

}
