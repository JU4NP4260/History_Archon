using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;

public class AudioManager : MonoBehaviour
{
    public Audio[] sounds;

    void Awake()
    {
        foreach (Audio s in sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.clip;

            s.Source.volume = s.volume;
            s.Source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Audio s = Array.Find(sounds, audio => audio.name == name);
        s.Source.Play();
    }
}
