using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Porte : MonoBehaviour {

    private Animator myAnimator;

	void Start () {
        myAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            myAnimator.SetBool("IsOpen", true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            myAnimator.SetBool("IsOpen", false);
        }
    }
}
