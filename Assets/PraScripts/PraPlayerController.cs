using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml;
using UnityEditor;
using UnityEngine;

public class PraPlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject shot;
    public Boundary boundary;
    public Transform shotSpawn;
    public float speed;
    public float tilt;

    public float fireRate;
    private float nextFire;

	// Use this for initialization
	void Start () 
    {
	   
	}
  
    void Update()
    {
        if (Input.GetButton("Fire1")&&Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    float moveHorizontal = Input.GetAxis("Horizontal");
	    float moveVertical = Input.GetAxis("Vertical");
	    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
	    rb.velocity = movement * speed;
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z,boundary.zMin,boundary.zMax)
        );
	    rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x*-tilt);
	}
}
