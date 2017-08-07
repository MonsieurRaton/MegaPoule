using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private float walkingOffset;
    [SerializeField] private Vector3 decalage; //Distance par rapport au personnage.
    [SerializeField] private Transform target;
    [SerializeField] private float smooth;
    //[SerializeField] private float borderDistance;
    /// <summary> Position que la camera doit atteindre </summary>
    private Vector3 camTargetPosition;

    void Start () {
        camTargetPosition = target.localPosition + decalage;
    }

    void Update () {

        /*Vector3 delta = target.localPosition - transform.localPosition;
        //print(delta);
        if (delta.x > borderDistance) {
            camTargetPosition = target.localPosition + decalage; //+ (Vector3.right * right);
        } else if (delta.x < -borderDistance) {
            camTargetPosition = target.localPosition + decalage;// - (Vector3.right * right);
        }*/
        if (target.localEulerAngles.y == 270f) {
            camTargetPosition = target.localPosition + decalage - (Vector3.right * walkingOffset);
        } else if (target.localEulerAngles.y == 90f) {
            camTargetPosition = target.localPosition + decalage + (Vector3.right * walkingOffset);
        } else {
            camTargetPosition = target.localPosition + decalage;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, camTargetPosition, smooth * Time.deltaTime);
    }

/*#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;

        Vector3 start = new Vector3(transform.localPosition.x + borderDistance, target.localPosition.y, target.localPosition.z);
        Vector3 end = start + Vector3.up * 3;
        Gizmos.DrawLine(start, end);
        start = new Vector3(transform.localPosition.x - borderDistance, target.localPosition.y, target.localPosition.z);
        end = start + Vector3.up * 3;
        Gizmos.DrawLine(start, end);
    }
#endif*/
}
