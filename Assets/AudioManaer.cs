using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManaer : MonoBehaviour
{
    private AudioClip endsound;
    private AudioClip music;
    public AudioSource sfx;
    public AudioSource ms;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        ms.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        ms.Stop();
        sfx.Play();
    }
}
