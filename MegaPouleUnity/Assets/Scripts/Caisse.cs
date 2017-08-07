using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caisse : MonoBehaviour {

    [SerializeField] private int life;

    private void OnCollisionEnter(Collision collision) {
        /*if (collision.transform.CompareTag("Projectile")) {
            life--;
            if (life <= 0) {
                Destroy(gameObject);
            }
        }*/
    }

    public void GrosPopotin() {
        life--;
        if (life <= 0) {
            Destroy(gameObject);
        }
    }


}
