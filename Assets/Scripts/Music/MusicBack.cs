using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBack : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicStart;

    // Start is called before the first frame update
    void Start()
    {
        //musicSource = GetComponent<AudioSource>();
        //musicSource.PlayOneShot(musicStart);
        //musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }

    // Update is called once per frame
    void Update()
    {
        if(!musicSource.isPlaying){
            musicSource.clip = musicStart;
            musicSource.Play();
        }
    }
}
