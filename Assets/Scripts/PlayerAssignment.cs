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
    private float timerSet;
    private float versusTimer;

    bool player01Set;

    public PlayerIndexes playerIndexes;

    private SoundManager soundManager;

    public void Start() {
        
        player1Index = 0;
        player2Index = 0;
        timer = 3.0f;
        timerSet = 0;
        versusTimer = 0.0f;

        soundManager = FindObjectOfType<SoundManager>();

        player01Set = false;
    }

	public void Update() {
        if (timerSet > 0)
        {
            timerSet += Time.deltaTime;
  
            if (timerSet > 3.0f)
            {
                timer -= Time.deltaTime;
                loadingImage.SetActive(true);

                if (timer < 0)
                {
                    Debug.Log("timer at zero");

                    SceneManager.LoadScene(3);
                }
            }
        }

        if (player01Set)
        {

            versusTimer += Time.deltaTime;

            if (versusTimer > 1.0f)
            {
                soundManager.PlaySound("Versus");
                player01Set = false;
            }

            
        }

        if (player1Index == 0 && Input.anyKeyDown)
        {
            for (int i = 1; i <= 11; i++)
            {
                if (Input.GetButton("Player" + i + "Start"))
                {

                    soundManager.PlaySound("E_Start");

                    player01Set = true;
                    
                    player1Index = i;
                    pressStart1.SetActive(false);
                    //player1.SetActive(true);
                    player1.GetComponent<Animator>().SetTrigger("player1On");
                    //player1BG.SetActive(true);
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
                        soundManager.PlaySound("F_Start");
                        player2Index = i;
                        pressStart2.SetActive(false);
                        //player2.SetActive(true);
                        player2.GetComponent<Animator>().SetTrigger("player2On");
                        //player2BG.SetActive(true);
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
            //versus.SetActive(true);
            GetComponent<Animator>().SetTrigger("start");
            playerIndexes.player1Index = player1Index;
            playerIndexes.player2Index = player2Index;

            timerSet += Time.deltaTime;
            Debug.Log("Timer Set");                           
        }
	}

}
