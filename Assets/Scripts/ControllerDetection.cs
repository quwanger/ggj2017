using UnityEngine;
using System.Collections;

public class ControllerDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    for(int i = 1; i <= 11; i++) {
            if (Input.GetAxisRaw("Player" + i + "Fire1") != 0) {
                //Debug.Log(i);
            }
        }
	}
}
