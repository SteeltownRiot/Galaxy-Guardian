﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    private Rigidbody rb;   // Holds cached rigidbody information for game object
    public float tumble;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }

    //// Update is called once per frame
    //void Update ()
    //   {

    //}
}
