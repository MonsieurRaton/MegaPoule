using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platiplap : MonoBehaviour {
    
    private Animator myAnimator;

    void Start() {
        myAnimator = GetComponent<Animator>();
    }

	// Update is called once per frame
	/*void Update () {
		
	}*/

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            myAnimator.SetBool("Active", true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            myAnimator.SetBool("Active", false);
        }
    }
}
