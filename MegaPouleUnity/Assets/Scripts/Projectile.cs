using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

    [SerializeField] private float startSpeed;

	void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * startSpeed; // Mise en place vitesse initiale.
        Destroy(gameObject, 5f); // Suppression au bout de 5 secondes.
	}
	

}
