using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody myRigidbody;
    private Animator myAnimator;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float jumpPower;
    [SerializeField] private float translationSpeed;
    [SerializeField] private GameObject projectile;
    /// <summary> Indique si la poule touche le sol. </summary>
    [SerializeField] private bool isGrounded;
    private int life;
    private int score;

    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponentInChildren<Animator>();
        transform.localPosition = spawnPoint.localPosition;
        life = 3;
        score = 0;
        CanvasManager.main.UpdateLifeText(life);
        CanvasManager.main.UpdateOtherText(score);
    }
	
	void Update () {

        isGrounded = Physics.Raycast(transform.localPosition + Vector3.up, Vector3.down, 1.01f);
        myAnimator.SetBool("IsJumping", !isGrounded); // bool "IsJumping"
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
            myRigidbody.AddForce(Vector3.up*jumpPower);
        }

#if UNITY_EDITOR
        Debug.DrawLine(transform.localPosition + Vector3.up, transform.localPosition+(Vector3.down*0.2f), Color.green);
#endif
        float horizontal = Input.GetAxisRaw("Horizontal"); // 0 1 ou -1

        if (horizontal != 0f) {

            //myRigidbody.AddForce((horizontal * translationSpeed) * Vector3.right, ForceMode.VelocityChange);
            
            myRigidbody.MovePosition(transform.localPosition + Vector3.right * (horizontal * translationSpeed * Time.deltaTime));
            if (horizontal > 0) {
                myRigidbody.MoveRotation(Quaternion.Euler(0, 90, 0));
            } else {
                myRigidbody.MoveRotation(Quaternion.Euler(0, -90, 0));
            }
        }else if (Input.GetAxisRaw("Vertical") == -1) {
            myRigidbody.MoveRotation(Quaternion.Euler(0, 180, 0));
        }
        myAnimator.SetBool("Run", horizontal != 0f);

        if (transform.localPosition.y < -10) { // Respawn
            Respawn();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(projectile, transform.localPosition + Vector3.up + transform.forward*1.5f, transform.localRotation);
        }

    }

    void Respawn() {
        transform.localPosition = spawnPoint.localPosition;
        myRigidbody.MoveRotation(Quaternion.Euler(0, 180, 0));
        myRigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bonus")) {
            Bonus bonus = other.GetComponent<Bonus>();
            life += bonus.bonusLife;
            score += bonus.bonusScore;
            bonus.Pick();
            CanvasManager.main.UpdateLifeText(life);
            CanvasManager.main.UpdateOtherText(score);
        }
    }



}
