using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private Spinner sp;


    private void Start()
    {
        sp = FindObjectOfType<Spinner>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sp.SpinInDirection(Spinner.Directions.Left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sp.SpinInDirection(Spinner.Directions.Right);
        }
    }
}
