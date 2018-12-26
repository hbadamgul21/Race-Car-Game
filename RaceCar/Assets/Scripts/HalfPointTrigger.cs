using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour {

    public GameObject LapCompleteTrigger;

    void OnTriggerEnter ()
    {
        LapCompleteTrigger.SetActive(true);
        gameObject.SetActive(false);
    }

}
