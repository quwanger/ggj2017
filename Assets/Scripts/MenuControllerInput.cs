using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControllerInput : MonoBehaviour {

    public GameObject loadingImage;
    private int currentScene;

    void Start() {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update () {
        BackButton();
	}

    void BackButton() {
        if (Input.GetButton("Player1Back") && currentScene != 0)
        {
            Debug.Log("BackButtonPressed");
            loadingImage.SetActive(true);
            SceneManager.LoadScene(0);
        }
    }
}
