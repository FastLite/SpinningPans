using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Forcer : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float defaultForce;
    private Direction currentDir;
    private List<Direction>  lastTwoDir = new List<Direction>();
    private int dirChangeCount;
    private Spinner sp;

    enum Direction
    {
        Right,Left
    }

    void Start()
    {
        sp = GetComponent<Spinner>();
        rb =GetComponent<Rigidbody>();
        StartCoroutine(ChooseNewDirection());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Spin(currentDir);
    }

    void Spin(Direction dir)
    {
        switch (dir)
        {
            case Direction.Left:
                rb.AddTorque(0, Random.Range(-2,0)*defaultForce,0, ForceMode.Impulse);
                return;
            case Direction.Right:
                rb.AddTorque(0, Random.Range(0,2)*defaultForce,0, ForceMode.Impulse);
                return;
        }
    }

    IEnumerator ChooseNewDirection()
    {
        dirChangeCount++;
        var allValues = Enum.GetValues(typeof(Direction));
        var newDir = (Direction) allValues.GetValue(Random.Range(0, 2));
        if (lastTwoDir.Count <2)
        {
            lastTwoDir.Add(currentDir);            
        }
        else
        {
            if (!lastTwoDir.Contains(Direction.Right))
            {
                newDir = Direction.Right;
            }
            else if (!lastTwoDir.Contains(Direction.Left))
            {
                newDir = Direction.Left;
            }
        }
        currentDir = newDir;
        Debug.Log("New direction is:"+newDir+"This is the "+dirChangeCount+" Loop");
        yield return new WaitForSeconds(Random.Range(2, 4));
        defaultForce += 0.02f;
        sp.Sensitivity += 2f;
        StartCoroutine(ChooseNewDirection());
    }

    



}
