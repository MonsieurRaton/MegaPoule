using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platiplap : MonoBehaviour {
    
    private Animator myAnimator;
    private Texture standardTexture;
    [SerializeField] private Texture hitTexture;
    private Material myMaterial;
    private IEnumerator coBlinking;

    void Start() {
        myAnimator = GetComponent<Animator>();
        myMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
        standardTexture = myMaterial.GetTexture("_MainTex");
    }

    // Update is called once per frame
    /*void Update () {
		
	}*/

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Projectile")) {
            Destroy(collision.gameObject);
        }
        Blink();
    }

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

    public void Blink() {
        if (coBlinking != null) {
            StopCoroutine(coBlinking);
        }
        coBlinking = Blinking();
        StartCoroutine(coBlinking);
    }

    private IEnumerator Blinking() {
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        for (int i = 0; i < 3; i++) {
            myMaterial.SetTexture("_MainTex", hitTexture);
            yield return wait;
            myMaterial.SetTexture("_MainTex", standardTexture);
            yield return wait;
        }
    }
}
