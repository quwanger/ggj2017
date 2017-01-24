using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
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

	public AudioClip[] englishStart;
	public AudioClip[] frenchStart;

	public AudioClip[] cheers;
	public AudioClip[] collisions;

	public AudioClip[] grunts;
	public AudioClip[] versus;

	public AudioSource[] sources;
	AudioSource soundEffects;
	AudioSource charging;
	AudioSource soundtrack;

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
	void Start()
	{
		sources = GetComponents<AudioSource>();
		charging = sources[0];
		soundtrack = sources[1];
		soundEffects = sources[2];
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void PlaySound(string word)
	{
		switch (word)
		{
			case "FUCK":
			soundEffects.PlayOneShot(fuck[Random.Range(0, fuck.Length)]);
			break;
			case "SHIT":
			soundEffects.PlayOneShot(shit[Random.Range(0, shit.Length)]);
			break;
			case "DAMN":
			soundEffects.PlayOneShot(damn[Random.Range(0, damn.Length)]);
			break;
			case "JESUS":
			soundEffects.PlayOneShot(jesus[Random.Range(0, jesus.Length)]);
			break;
			case "ASSHOLE":
			soundEffects.PlayOneShot(asshole[Random.Range(0, asshole.Length)]);
			break;
			case "DICKHEAD":
			soundEffects.PlayOneShot(dickhead[Random.Range(0, dickhead.Length)]);
			break;
			case "FUCKFACE":
			soundEffects.PlayOneShot(fuckface[Random.Range(0, fuckface.Length)]);
			break;
			case "PIECEofSHIT":
			soundEffects.PlayOneShot(pieceofshit[Random.Range(0, pieceofshit.Length)]);
			break;
			case "MOTHERFUCKER":
			soundEffects.PlayOneShot(motherfucker[Random.Range(0, motherfucker.Length)]);
			break;
			case "SONofaBITCH":
			soundEffects.PlayOneShot(sonofabitch[Random.Range(0, sonofabitch.Length)]);
			break;
			case "CRISS":
			soundEffects.PlayOneShot(criss[Random.Range(0, criss.Length)]);
			break;
			case "MERDE":
			soundEffects.PlayOneShot(merde[Random.Range(0, merde.Length)]);
			break;
			case "ESTI":
			soundEffects.PlayOneShot(esti[Random.Range(0, esti.Length)]);
			break;
			case "TaGUEULE":
			soundEffects.PlayOneShot(tagueuele[Random.Range(0, tagueuele.Length)]);
			break;
			case "MAUDIT":
			soundEffects.PlayOneShot(maudit[Random.Range(0, maudit.Length)]);
			break;
			case "CALISSE":
			soundEffects.PlayOneShot(calisse[Random.Range(0, calisse.Length)]);
			break;
			case "VaCHIER":
			soundEffects.PlayOneShot(vachier[Random.Range(0, vachier.Length)]);
			break;
			case "TABARNAK":
			soundEffects.PlayOneShot(tabarnak[Random.Range(0, tabarnak.Length)]);
			break;
			case "E_Hit":
			soundEffects.PlayOneShot(englishHurt[Random.Range(0, englishHurt.Length)]);
			break;
			case "F_Hit":
			soundEffects.PlayOneShot(frenchHurt[Random.Range(0, frenchHurt.Length)]);
			break;
			case "E_Lose":
			soundEffects.PlayOneShot(englishDead[Random.Range(0, englishDead.Length)]);
			break;
			case "F_Lose":
			soundEffects.PlayOneShot(frenchDead[Random.Range(0, frenchDead.Length)]);
			break;
			case "E_Win":
			soundEffects.PlayOneShot(englishWin[Random.Range(0, englishWin.Length)]);
			break;
			case "F_Win":
			soundEffects.PlayOneShot(frenchWin[Random.Range(0, frenchWin.Length)]);
			break;
			case "collisions":
			soundEffects.PlayOneShot(collisions[Random.Range(0, collisions.Length)]);
			break;
			case "E_Charge":
			charging.PlayOneShot(englishCharge[Random.Range(0, englishCharge.Length)], 0.6f);
			break;
			case "F_Charge":
			soundEffects.PlayOneShot(frenchCharge[Random.Range(0, frenchCharge.Length)], 0.6f);
			break;
			case "E_Start":
			soundEffects.PlayOneShot(englishStart[Random.Range(0, englishStart.Length)]);
			break;
			case "F_Start":
			soundEffects.PlayOneShot(frenchStart[Random.Range(0, frenchStart.Length)]);
			break;
			case "Versus":
			soundEffects.PlayOneShot(versus[Random.Range(0, versus.Length)]);
			break;
			case "Cheers":
			soundEffects.PlayOneShot(cheers[Random.Range(0, cheers.Length)]);
			break;
			default:
			soundEffects.PlayOneShot(grunts[Random.Range(0, grunts.Length)]);
			break;
		}
	}
}
