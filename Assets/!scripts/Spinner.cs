using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private float sensitivity = 10;

    public float Sensitivity
    {
        get => sensitivity;
        set => sensitivity = value;
    }
    [SerializeField]private float loseValue = 10;
    private UImanager ui;
    private GameManager gm;
    private bool lost;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        ui = FindObjectOfType<UImanager>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.maxAngularVelocity = Single.PositiveInfinity;
    }

    private void FixedUpdate()
    {
        if (GetPercent()>1 &&!lost) //If spin speed is too high→lose
        { 
            rb.AddExplosionForce(rb.angularVelocity.y,
                new Vector3(0, 0.5f, -3.58f), 1, 0,ForceMode.Impulse);
            lost = true;
            gm.Lost();

        }
        else if (!lost)
        {
            ui.UpdateScore( Mathf.Abs(GetTorquePerFixedUpdate()));
            ui.ChangeBarValue(GetPercent());
        }
    }

    public enum Directions
    {
        Left, Right
    }
    public void SpinInDirection(Directions directions)
    {
        if (lost)
            return;
        
        switch (directions)
        {
            case Directions.Left:
                rb.AddTorque(new Vector3(0,sensitivity,0)*Time.deltaTime, ForceMode.Impulse); //change force mode to take mass into account
                return;
            case Directions.Right:
                rb.AddTorque(new Vector3(0,-sensitivity,0)*Time.deltaTime, ForceMode.Impulse); //change force mode to take mass into account
                return;
        }
    }
    
    public void SpinInDirection(bool right)
    {
        if (lost)
            return;
        switch (right)
        {
            case false:
                rb.AddTorque(new Vector3(0,sensitivity,0)*Time.deltaTime, ForceMode.Impulse); //change force mode to take mass into account
                return;
            case true:
                rb.AddTorque(new Vector3(0,-sensitivity,0)*Time.deltaTime, ForceMode.Impulse); //change force mode to take mass into account
                return;
        }
    }

    float GetPercent()
    {
        var result = 0f;
        result = (rb.angularVelocity.y/loseValue); 
        result = Mathf.Abs(result); //get rid of minus
        return result;
    }
    public float GetTorquePerFixedUpdate()
    {
        var result = 0f;
        result = (rb.angularVelocity.y) / 50;
        return result;
    }
    
}
