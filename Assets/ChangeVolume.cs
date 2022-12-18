using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolume : MonoBehaviour
{
    private AudioListener au;
    private float saved;

    private void Start()
    {
        DontDestroyOnLoad(this);
        AudioListener.volume = saved;
    }

    public void ChangeVol(float i)
    {
        saved = i;
        AudioListener.volume = saved;
    }
}
