using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kopter : MonoBehaviour {

    [SerializeField] private float rotorRotationSpeed;
    [SerializeField] private Transform rotorBone;
    private Animator myAnimator;

    void Start () {
        myAnimator = GetComponent<Animator>();
    }
	
	void Update () {
        rotorBone.Rotate(0, 0, rotorRotationSpeed * Time.deltaTime, Space.Self);
    }


    private void OnCollisionEnter(Collision collision) {
            myAnimator.Play("Hit");
            if (collision.transform.CompareTag("Projectile")) {
                Destroy(collision.gameObject);
            }
        
    }

    private void OnTriggerEnter(Collider other) {
        print(other.tag);
        if (other.CompareTag("Player")) {
            rotorRotationSpeed *= 2;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            rotorRotationSpeed /= 2;
        }
    }


}
