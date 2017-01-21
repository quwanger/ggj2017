using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuSelection : MonoBehaviour {

    public GameObject selected;

    private int selectionIndex;
    private float axis;

    // Use this for initialization
    void Start () {
        selectionIndex = 1;
        axis = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

	    if(Input.GetAxis("Player1MoveY") < 0) {
            if (selectionIndex < 3)
            {
                selectionIndex++;
                selected.transform.Translate(Vector3.down * 50);
            }
               
        }
        else if(Input.GetAxis("Player1MoveY") > 0) {
            if (selectionIndex > 1)
            {
                selectionIndex--;
                selected.transform.Translate(Vector3.up * 50);
            } 
        }
    }

    void MoveDown(float delay) {
        if (Input.GetAxis("Player1MoveY") < 0) {
            if (selectionIndex < 3)
                selectionIndex++;
        }
    }

    void AdjustSelectionIndex(bool increase) {
        if (increase && selectionIndex < 3)
            selectionIndex++;
        else if (increase == false && selectionIndex > 1)
            selectionIndex--;
    }
}
