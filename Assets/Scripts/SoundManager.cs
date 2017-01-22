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

    public AudioClip[] grunts;

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
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "SHIT":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "DAMN":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "JESUS":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "ASSHOLE":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "DICKHEAD":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "FUCKFACE":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "PIECEofSHIT":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "MOTHERFUCKER":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "SONofaBITCH":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "CRISS":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "MERDE":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "ESTI":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "TaGUEULE":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "MAUDIT":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "CALISSE":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "VaCHIER":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "TABARNAK":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            default:
                audio.GetComponent<AudioSource>().PlayOneShot(grunts[Random.Range(0, grunts.Length)]);
                break;
        }
    }
}
