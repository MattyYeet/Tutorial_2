
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip winMusic;
    public AudioClip loopMusic;
    public AudioSource musicSource;

    public GameObject condition;

    // Update is called once per frame
    void Awake()
    {
        musicSource.clip = loopMusic;
        musicSource.Play();
        musicSource.loop = true;
    }
    
    void LateUpdate()
    {
        if(condition.activeSelf == false){
            musicSource.clip = winMusic;
            musicSource.Play();
            musicSource.loop = true;
        }
    }
}
