using UnityEngine;
using System.Collections;

public class OptionsMenuEffects : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MakeCensored() {
        PlayerPrefs.SetInt("polite", 1);
    }

    public void MakeUncensored() {
        PlayerPrefs.SetInt("polite", 0);
    }
}
