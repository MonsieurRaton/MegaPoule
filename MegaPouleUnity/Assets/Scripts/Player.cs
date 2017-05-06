using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody myRigidbody;
    [SerializeField] private float jumpPower;
    [SerializeField] private float translationSpeed;
    [SerializeField] private GameObject projectile;

    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow) && Physics.Raycast(transform.localPosition + Vector3.up, Vector3.down, 1.2f)) {
            myRigidbody.AddForce(Vector3.up*jumpPower);
        }
#if UNITY_EDITOR
        Debug.DrawLine(transform.localPosition + Vector3.up, transform.localPosition+(Vector3.down*0.2f), Color.green);
#endif
        float horizontal = Input.GetAxisRaw("Horizontal"); // 0 1 ou -1
        myRigidbody.AddForce((horizontal * translationSpeed) * Vector3.right, ForceMode.VelocityChange);
        if (horizontal != 0f) {
            //
            //myRigidbody.MovePosition(transform.localPosition + Vector3.right * horizontal * translationSpeed * Time.deltaTime);
            if (horizontal > 0) {
                myRigidbody.MoveRotation(Quaternion.Euler(0, 90, 0));
            } else {
                myRigidbody.MoveRotation(Quaternion.Euler(0, -90, 0));
            }
        }

        if (transform.localPosition.y < -10) { // Respawn
            transform.localPosition = new Vector3(3, 2, 0);
            transform.localEulerAngles = new Vector3(0, 0, 0);
            myRigidbody.velocity = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.RightControl)) {
            Instantiate(projectile, transform.localPosition + Vector3.up + transform.forward*1.5f, transform.localRotation);
        }

    }



}
