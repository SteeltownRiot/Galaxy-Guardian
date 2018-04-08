using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private Rigidbody rb;   // Holds cached rigidbody information for game object
    public float speed;     // Holds speed of laser bolts

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    //// Update is called once per frame
    //void Update ()
    //   {

    //}
}
