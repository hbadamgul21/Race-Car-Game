using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTrigger : MonoBehaviour {

    public GameObject halfPointTrigger;

    private void OnTriggerEnter(Collider other){
        
        CarController car;
        if (car = other.gameObject.GetComponentInParent<CarController>()){

            car.CompleteLap();
            gameObject.SetActive(false);
            halfPointTrigger.SetActive(true);
        }
    }
}
