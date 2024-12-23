using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource source;
    private void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
    }
    public void playSound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }
}
