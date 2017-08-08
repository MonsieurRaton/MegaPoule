using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    public static CanvasManager main;

    [SerializeField] private Text lifeText;
    [SerializeField] private Text pieceText;

    void Awake () {
        if (main == null) {
            main = this;
        } else {
            Debug.LogError("Deux CanvasManager sur la scène !");
            Destroy(this);
        }
	}
	
	public void UpdateLifeText (int newLife) {
        lifeText.text = "x " + newLife;
    }

    public void UpdatePieceText(int newScore) {
        pieceText.text = ": " + newScore;
    }
}
