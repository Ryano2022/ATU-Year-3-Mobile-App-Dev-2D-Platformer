using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip bgMusic;

    void Start() {
        musicSource.clip = bgMusic;
        musicSource.Play();
    }
}
