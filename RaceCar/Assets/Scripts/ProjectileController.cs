using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public GameObject target;
    public float homingPower;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 force = target.transform.position - transform.position;
        force.y = 0;

        if(force.sqrMagnitude > homingPower * homingPower){

            force.Normalize();
            force *= homingPower;
        }

        rb.AddForce(force);
	}

    void OnCollisionEnter(Collision collision){
        
        foreach(ContactPoint contact in collision.contacts){

            CarController car;
            if (car = contact.otherCollider.gameObject.GetComponentInParent<CarController>()){

                car.Damage(20);
                break;
            }
        }

        Destroy(gameObject);
    }
}
