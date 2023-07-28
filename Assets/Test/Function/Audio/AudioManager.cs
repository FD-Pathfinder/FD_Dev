using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    private AudioSource MyUIAudioSource;

    public AudioClip[] AudioBePlay;

    public static int whichtoplay=0;
    private void Awake()
    {
        Initialized_me();
        Mano_InputManger.IAmRelease += PlayUISound;
        Mano_InputManger.IAmTouching += PlayUISound;
        FD_UI_Debugstate.test += PlayUISound;
    }
    private void Initialized_me()
    {
        MyUIAudioSource= GetComponent<AudioSource>();
    }

    public void PlayUISound()
    {
        MyUIAudioSource.clip= AudioBePlay[whichtoplay];
        MyUIAudioSource.Play();
    }

}
