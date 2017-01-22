using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerAssignment : MonoBehaviour {
    public GameObject player1;
    public GameObject player1BG;
    public GameObject player2;
    public GameObject player2BG;
    public GameObject pressStart1;
	public GameObject pressStart2;
    public GameObject versus;
    public GameObject loadingImage;

    public int player1Index;
    public int player2Index;
    private float timer;
    private bool timerSet;

    public PlayerIndexes playerIndexes;

    public void Start() {
        
        player1Index = 0;
        player2Index = 0;
        timer = 3.0f;
        timerSet = false;
    }

	public void Update() {
        if (timerSet)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Debug.Log("timer at zero");
                loadingImage.SetActive(true);
                SceneManager.LoadScene(3);
            }
        }
        
        if (player1Index == 0 && Input.anyKeyDown)
        {
            for (int i = 1; i <= 11; i++)
            {
                if (Input.GetButton("Player" + i + "Start"))
                {
                    player1Index = i;
                    pressStart1.SetActive(false);
                    player1.SetActive(true);
                    player1BG.SetActive(true);
                    checkIfDone();
                }
            }
        }

        else if (player1Index != 0 && player2Index == 0 && Input.anyKeyDown)
        {
            for (int i = 1; i <= 11; i++)
            {
                if (Input.GetButton("Player" + i + "Start"))
                {
                    if (player1Index != i)
                    {
                        player2Index = i;
                        pressStart2.SetActive(false);
                        player2.SetActive(true);
                        player2BG.SetActive(true);
                        checkIfDone();
                    }
                }
            }
        }
        else if (Input.GetButton("Player1Back"))
        {
            loadingImage.SetActive(true);
            SceneManager.LoadScene(0);
        }

	}

	private void checkIfDone() {

		if(player1Index != 0 && player2Index != 0) {
            versus.SetActive(true);
            playerIndexes.player1Index = player1Index;
            playerIndexes.player2Index = player2Index;

            timerSet = true;
            Debug.Log("Timer Set");
            //StartCoroutine(Timeout());                               
        }
	}

    IEnumerator Timeout()
    {
        loadingImage.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }

}
