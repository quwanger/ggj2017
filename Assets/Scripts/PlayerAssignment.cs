using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerAssignment : MonoBehaviour {
    public GameObject text1;
	public GameObject text2;
    public GameObject loadingImage;

    private int player1Index;
    private int player2Index;

    public void Start() {
        player1Index = 0;
        player2Index = 0;
    }

	public void Update() {
        if (player1Index == 0 && Input.anyKeyDown) {
            for (int i = 1; i <= 11; i++) {
                if (Input.GetButton("Player" + i + "Start")) {
                    player1Index = i;
                    checkIfDone();
                }
            }
        }

        else if (player1Index != 0 && player2Index == 0 && Input.anyKeyDown) {
            for (int i = 1; i <= 11; i++) {
                if (Input.GetButton("Player" + i + "Start")) {
                    if (player1Index != i)
                        player2Index = i;
                    checkIfDone();
                }
            }
        }

	}

	private void checkIfDone() {
		if(player1Index != 0 && player2Index != 0) {
            text1.SetActive(false);
            text2.SetActive(false);
            loadingImage.SetActive(true);
            SceneManager.LoadScene(3);
        }
		else {
			text1.SetActive(false);
			text2.SetActive(true);
		}
	}

}
