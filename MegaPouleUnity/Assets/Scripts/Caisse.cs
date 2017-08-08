using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caisse : MonoBehaviour {

    [SerializeField] private int life;
    [SerializeField] private GameObject prefabParticulesDestruction;
    

    public void GrosPopotin() {
        life--;
        if (life <= 0) {
            GameObject particules = Instantiate(prefabParticulesDestruction, transform.position + Vector3.up*1.5f, Quaternion.identity);
            Destroy(particules, 2);
            Destroy(gameObject);
        }
    }


}
