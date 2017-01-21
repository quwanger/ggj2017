using UnityEngine;
using System.Collections;

public class PlayerAssignment : MonoBehaviour {

	public GameObject text1;
	public GameObject text2;

	static int player1Index = 0;
  static int player2Index = 0;

	public void Update() {
		if(player1Index == 0 && Input.anyKeyDown) {
			for (int i = 1; i <= 11; i++) {
				if (Input.GetButton("Player" + i + "Start")) {
					player1Index = i;
					checkIfDone();
				}
			}
		}
			
		if(player2Index == 0 && Input.anyKeyDown) {
			for (int i = 1; i <= 11; i++) {
				if (Input.GetButton("Player" + i + "Start") && player2Index == 0)	{
					if (player1Index != i)
						player2Index = i;
					checkIfDone();
				}
			}
		}

	}

	private void checkIfDone() {
		if(player1Index != 0 && player2Index != 0) {
			Application.LoadLevel(3);
		}
		else {
			text1.SetActive(false);
			text2.SetActive(true);
		}
	}

}
