using UnityEngine;
using System.Collections;

public class PlayerIndexes : MonoBehaviour {

    public int player1Index = 0;
    public int player2Index = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
