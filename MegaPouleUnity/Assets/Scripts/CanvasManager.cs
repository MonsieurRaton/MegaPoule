using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    public static CanvasManager main;

    [SerializeField] private Text lifeText;
    [SerializeField] private Text otherText;

    void Awake () {
        if (main == null) {
            main = this;
        } else {
            Debug.LogError("Deux CanvasManager sur la scène !");
            Destroy(this);
        }
	}
	
	public void UpdateLifeText (int newLife) {
        lifeText.text = "Vie: " + newLife;
    }

    public void UpdateOtherText(int newScore) {
        otherText.text = "Energie: XX/YY\nArme actuelle : Cailloux(∞)\nPièces: " + newScore;
    }
}
