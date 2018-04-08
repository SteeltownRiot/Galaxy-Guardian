using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float leftMax,   // Holds maximum distance ship can move left
                 rightMax,  // Holds maximum distance ship can move right
                 downMax,   // Holds maximum distance ship can move down
                 upMax;     // Holds maximum distance ship can move up
}

public class PlayerController : MonoBehaviour
{
    public float movementSpeed,     // Holds speed multiplier for ship movement
                 tilt,              // Holds the tilt of the ship as it maneuvers
                 fireRate;          // Holds rate lasers can be fired
    private float nextFire;         // holds minimum time between shots
    private Rigidbody rb;           // Holds cached rigidbody information for game object
    public Boundary boundary;       // Holds the boundary parameters
    public GameObject shot;         // 
    public Transform shotSpawn;     // 
    private AudioSource audioSource;// 

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        
        Vector3 shipMovement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);

        rb.velocity = shipMovement * movementSpeed;
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.leftMax, boundary.rightMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.downMax, boundary.upMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
