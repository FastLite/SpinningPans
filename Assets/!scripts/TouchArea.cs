using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchArea : MonoBehaviour
{
    private Spinner spin;

    private void Start()
    {
        spin = FindObjectOfType<Spinner>();
    }

    private void FixedUpdate()
    {
            if (Input.GetMouseButton(0))
            {
                var wp = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                float touchPos = wp.x;
                if (touchPos < 0.5)
                {
                    spin.SpinInDirection(Spinner.Directions.Left);
 
                }
                else if (touchPos > 0.5)
                {
                    spin.SpinInDirection(Spinner.Directions.Right);
                }
            }
            if (Input.touchCount > 0 )
            {
                var i = Input.touchCount;
                    Vector3 wp = Camera.main.ScreenToViewportPoint(Input.GetTouch(i-1).position);
                    float touchPos = wp.x;
                    if (touchPos < 0.5)
                    {
                        spin.SpinInDirection(Spinner.Directions.Left);
 
                    }
                    else if (touchPos > 0.5)
                    { 
                        spin.SpinInDirection(Spinner.Directions.Right);
                    }
                    
            }
    }
}
