using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {
    public GameObject loadingImage;

    public void Update() {
        BackToMainMenu();
    }


    public void LoadScene(int scene) {
        loadingImage.SetActive(true);
        SceneManager.LoadScene(scene);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        if (Input.GetButton("Player1Back"))
        {
            loadingImage.SetActive(true);
            SceneManager.LoadScene(0);
        }
    }
}
