using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource itemAudioSource;
    public AudioSource attackAudioSource;
    public AudioSource skillAudioSource;
    public AudioSource avoidAudioSource;
    public AudioSource clickAudioSource;
    public AudioSource bombAudioSource;
    // public AudioSource itemAudioSource;
    public AudioClip itemSound;
    public AudioClip attackSound;
    public AudioClip bombSound;
    public AudioClip avoidSound;
    public void PlayItemSound()
    {
        itemAudioSource.clip = itemSound;
        itemAudioSource.Play();
    }
    public void PlayAttackSound()
    {
        attackAudioSource.Play();
    }
    public void PlayClickSound()
    {
        clickAudioSource.Play();
    }
    public void PlayAvoidSound()
    {
        avoidAudioSource.Play();
    }
    public void PlayBombSound()
    {
        bombAudioSource.Play();
    }
    public void PlaySkillSound()
    {
        skillAudioSource.Play();
    }
}
