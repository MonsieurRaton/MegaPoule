using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

    public int bonusScore;
    public int bonusLife;
    /// <summary> L'objet a t-il déjà été rammasser ? </summary>
    public bool picked;
    private Animator myAnimator;

    void Start () {
#if UNITY_EDITOR
        if (!gameObject.CompareTag("Bonus")) {
            Debug.LogWarning("Un bonus ne possède pas le bon tag.");
        }
#endif
        myAnimator = GetComponent<Animator>();
    }

    public void Pick() {
        picked = true;
        myAnimator.SetBool("Picked", true);
        Destroy(gameObject, 0.5f);
    }

}
