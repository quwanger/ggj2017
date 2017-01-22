using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public AudioClip[] criss;
    public AudioClip[] merde;
    public AudioClip[] esti;
    public AudioClip[] tagueuele;
    public AudioClip[] maudit;
    public AudioClip[] calisse;
    public AudioClip[] vachien;
    public AudioClip[] tabarnak;
    public AudioClip[] sacrament;
    public AudioClip[] groscave;

    public AudioClip[] frenchHurt;
    public AudioClip[] frenchWin;
    public AudioClip[] frenchDead;
    public AudioClip[] frenchCharge;

    public AudioClip[] fuck;
    public AudioClip[] shit;
    public AudioClip[] damn;
    public AudioClip[] jesus;
    public AudioClip[] asshole;
    public AudioClip[] dickhead;
    public AudioClip[] fuckface;
    public AudioClip[] pieceofshit;
    public AudioClip[] motherfucker;
    public AudioClip[] sonofabitch;

    public AudioClip[] englishHurt;
    public AudioClip[] englishWin;
    public AudioClip[] englishDead;
    public AudioClip[] englishCharge;

    public AudioClip[] cheers;
    public AudioClip[] collisions;

    public GameObject audio;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySound(string word)
    {
        switch (word)
        {
            case "FUCK":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[0]);
                break; 
        }
    }
}
