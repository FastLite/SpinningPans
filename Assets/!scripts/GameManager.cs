using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    private int score;
    private UImanager ui;
    private AudioManaer am;
    private bool lost;

    private void Start()
    {
        ui =  FindObjectOfType<UImanager>();
        am = FindObjectOfType<AudioManaer>();
    }

    private void FixedUpdate()
    {
        if (lost)
            return;
        score = Mathf.CeilToInt(Time.timeSinceLevelLoad);
        
    }

    public void Setup()
    {
        
    }
    public void Lost()
    {
        lost = true;
        endScreen.SetActive(true);
        FindObjectOfType<Forcer>().StopAllCoroutines();
        FindObjectOfType<Forcer>().enabled = false;
        am.GameOver();
    }
}
