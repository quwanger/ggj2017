using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    static SoundManager instance = null;

    public AudioClip[] criss;
    public AudioClip[] merde;
    public AudioClip[] esti;
    public AudioClip[] tagueuele;
    public AudioClip[] maudit;
    public AudioClip[] calisse;
    public AudioClip[] vachier;
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

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySound(string word)
    {
        Debug.Log(word);

        switch (word)
        {
            case "FUCK":
                audio.GetComponent<AudioSource>().PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
                break;
            case "SHIT":
                audio.GetComponent<AudioSource>().PlayOneShot(shit[Random.Range(0, shit.Length)]);
                break;
            case "DAMN":
                audio.GetComponent<AudioSource>().PlayOneShot(damn[Random.Range(0, damn.Length)]);
                break;
            case "JESUS":
                audio.GetComponent<AudioSource>().PlayOneShot(jesus[Random.Range(0, jesus.Length)]);
                break;
            case "ASSHOLE":
                audio.GetComponent<AudioSource>().PlayOneShot(asshole[Random.Range(0, asshole.Length)]);
                break;
            case "DICKHEAD":
                audio.GetComponent<AudioSource>().PlayOneShot(dickhead[Random.Range(0, dickhead.Length)]);
                break;
            case "FUCKFACE":
                audio.GetComponent<AudioSource>().PlayOneShot(fuckface[Random.Range(0, fuckface.Length)]);
                break;
            case "PIECEofSHIT":
                audio.GetComponent<AudioSource>().PlayOneShot(pieceofshit[Random.Range(0, pieceofshit.Length)]);
                break;
            case "MOTHERFUCKER":
                audio.GetComponent<AudioSource>().PlayOneShot(motherfucker[Random.Range(0, motherfucker.Length)]);
                break;
            case "SONofaBITCH":
                audio.GetComponent<AudioSource>().PlayOneShot(sonofabitch[Random.Range(0, sonofabitch.Length)]);
                break;
            case "CRISS":
                audio.GetComponent<AudioSource>().PlayOneShot(criss[Random.Range(0, criss.Length)]);
                break;
            case "MERDE":
                audio.GetComponent<AudioSource>().PlayOneShot(merde[Random.Range(0, merde.Length)]);
                break;
            case "ESTI":
                audio.GetComponent<AudioSource>().PlayOneShot(esti[Random.Range(0, esti.Length)]);
                break;
            case "TaGUEULE":
                audio.GetComponent<AudioSource>().PlayOneShot(tagueuele[Random.Range(0, tagueuele.Length)]);
                break;
            case "MAUDIT":
                audio.GetComponent<AudioSource>().PlayOneShot(maudit[Random.Range(0, maudit.Length)]);
                break;
            case "CALISSE":
                audio.GetComponent<AudioSource>().PlayOneShot(calisse[Random.Range(0, calisse.Length)]);
                break;
            case "VaCHIER":
                audio.GetComponent<AudioSource>().PlayOneShot(vachier[Random.Range(0, vachier.Length)]);
                break;
            case "TABARNAK":
                audio.GetComponent<AudioSource>().PlayOneShot(tabarnak[Random.Range(0, tabarnak.Length)]);
                break;
            case "E_Hit":
                audio.GetComponent<AudioSource>().PlayOneShot(englishHurt[Random.Range(0, englishHurt.Length)]);
                break;
            case "F_Hit":
                audio.GetComponent<AudioSource>().PlayOneShot(frenchHurt[Random.Range(0, frenchHurt.Length)]);
                break;
            case "E_Lose":
                audio.GetComponent<AudioSource>().PlayOneShot(englishDead[Random.Range(0, englishDead.Length)]);
                break;
            case "F_Lose":
                audio.GetComponent<AudioSource>().PlayOneShot(frenchDead[Random.Range(0, frenchDead.Length)]);
                break;
            case "E_Win":
                audio.GetComponent<AudioSource>().PlayOneShot(englishWin[Random.Range(0, englishWin.Length)]);
                break;
            case "F_Win":
                audio.GetComponent<AudioSource>().PlayOneShot(frenchWin[Random.Range(0, frenchWin.Length)]);
                break;
            default:
                audio.GetComponent<AudioSource>().PlayOneShot(grunts[Random.Range(0, grunts.Length)]);
                break;
        }
    }
}
