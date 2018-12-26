using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour {

    public Rigidbody target;
    public GameObject projectile;
    public float randomness;
    public float topSpeed;
    public float acceleration;
    public int cooldown;

    private Rigidbody rb;
    private Collider cldr;
    private float height;
    private int counter;

	// Use this for initialization
	void Start(){

        rb = GetComponent<Rigidbody>();
        cldr = GetComponent<Collider>();
        height = transform.position.y;
        counter = cooldown;
	}

    // Update is called once per frame
    void Update() {
        
        Vector3 movement = target.position + target.velocity - rb.position;
        movement.y = height - transform.position.y;

        if (movement.sqrMagnitude > topSpeed * topSpeed) {
            movement.Normalize();
            movement *= topSpeed;
        }
        
        Vector3 adjust = movement - rb.velocity;

        if (adjust.sqrMagnitude > acceleration * acceleration) {
            adjust.Normalize();
            adjust *= acceleration;
        }
        
        rb.AddForce(rb.mass * adjust);

        if(counter == 0){

            counter = cooldown;
            ShootProjectile();
        }
        else
            --counter;
	}


    void ShootProjectile(){

        Vector3 spawnPosition = transform.position;
        spawnPosition.y -= transform.lossyScale.y;

        GameObject instantiated = Instantiate(projectile, spawnPosition, transform.rotation);
        instantiated.GetComponent<Rigidbody>().velocity = rb.velocity;
        Physics.IgnoreCollision(instantiated.GetComponent<Collider>(), cldr, true);
    }
}
