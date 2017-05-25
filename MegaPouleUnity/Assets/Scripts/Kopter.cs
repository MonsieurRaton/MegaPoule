﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kopter : MonoBehaviour {

    [SerializeField] private float rotorRotationSpeed;
    [SerializeField] private Transform rotorBone;
    [SerializeField] private Color hitColor;
    private Animator myAnimator;
    private Material myMaterial;
    private IEnumerator coBlinking;

    void Start () {
        myAnimator = GetComponent<Animator>();
        myMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
    }
	
	void Update () {
        rotorBone.Rotate(0, 0, rotorRotationSpeed * Time.deltaTime, Space.Self);
    }


    private void OnCollisionEnter(Collision collision) {
        myAnimator.Play("Hit");
        if (collision.transform.CompareTag("Projectile")) {
            Destroy(collision.gameObject);
        }
        Blink();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            rotorRotationSpeed *= 2;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            rotorRotationSpeed /= 2;
        }
    }

    public void Blink() {
        if (coBlinking != null) {
            StopCoroutine(coBlinking);
        }
        coBlinking = Blinking();
        StartCoroutine(coBlinking);
    }

    private IEnumerator Blinking() {
        WaitForSeconds wait = new WaitForSeconds(0.08f);
        for (int i = 0; i<3; i++) {
            myMaterial.color = hitColor;
            yield return wait;
            myMaterial.color = Color.white;
            yield return wait;
        }
    }

}
