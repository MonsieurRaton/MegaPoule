using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private int height;
    [SerializeField] private int distance;
    [SerializeField] private Transform target;
    [SerializeField] private float smooth;

    /*void Start () {
		
	}*/
	
	void Update () {
        Vector3 targetPosition = target.localPosition + (Vector3.forward * distance) + (Vector3.up * height);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, smooth*Time.deltaTime);

    }
}
