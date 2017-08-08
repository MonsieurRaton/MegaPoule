using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kopter : MonoBehaviour {

    [SerializeField] private float rotorRotationSpeed;
    [SerializeField] private Transform rotorBone;
    private Texture standardTexture;
    [SerializeField] private Texture hitTexture;
    private Animator myAnimator;
    private Material myMaterial;
    private IEnumerator coBlinking;

    void Start () {
        myAnimator = GetComponent<Animator>();
        myMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
        standardTexture = myMaterial.GetTexture("_MainTex");
    }
	
	void Update () {
        rotorBone.Rotate(0, rotorRotationSpeed * Time.deltaTime, 0, Space.Self);
    }


    private void OnCollisionEnter(Collision collision) {
        myAnimator.Play("Hit");
        Blink();
        if (collision.transform.CompareTag("Projectile")) {
            Destroy(collision.gameObject);
        }
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
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        for (int i = 0; i<3; i++) {
            myMaterial.SetTexture("_MainTex", hitTexture);
            yield return wait;
            myMaterial.SetTexture("_MainTex", standardTexture);
            yield return wait;
        }
    }

}
