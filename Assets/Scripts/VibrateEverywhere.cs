using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class VibrateEverywhere : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("MenuConfirm") || Input.GetButton("MenuA")) {
            StartCoroutine(FireVibrate());
        }
	}

    IEnumerator FireVibrate() {
        for(int i = 0; i < 4; i++) {
            Debug.Log((PlayerIndex)i);
            //GamePad.SetVibration((PlayerIndex)i, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.3f);
            //GamePad.SetVibration((PlayerIndex)i, 0f, 0f);
        }
    }
}
