using UnityEngine;
using System.Collections;

public class MainMenuEffects : MonoBehaviour {

    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject exitButton;
    public GameObject canvas;
    public int moveSpeed = 2000;

    // Use this for initialization
    void Start () {
        playButton.transform.Translate(-1000, 0, 0);
        optionsButton.transform.Translate(1000, 0, 0);
        exitButton.transform.Translate(-1000, 0, 0);
}
	
	// Update is called once per frame
	void Update () {
        if (playButton.transform.position.x - canvas.transform.position.x < 0) {
            playButton.transform.Translate(Vector3.right * 2000 * Time.deltaTime);
        }
        else {
            if(optionsButton.transform.position.x - canvas.transform.position.x > 0) {
                optionsButton.transform.Translate(Vector3.right * -2000 * Time.deltaTime);
            }
            else {
                if (exitButton.transform.position.x - canvas.transform.position.x < 0){
                    exitButton.transform.Translate(Vector3.right * 2000 * Time.deltaTime);
                }
            }
        }
        
               
	}
}
