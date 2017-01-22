using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LetterProjectile : MonoBehaviour {

    public Word word;
    public Text text;
    public string letter;
    public float damage = 1;

    public bool active = false;
    public float life = 0.0f;
    public float timeout = 5.0f;

    public float health = 1;

    public float startOpacity = 0.3f;

    public ParticleSystem sparkParticles;

	// Use this for initialization
	void Start () {
	    if(word.owner.teamIndex == 0) {
            text.color = new Color(1, 0, 0, startOpacity);
        } else if(word.owner.teamIndex == 1) {
            text.color = new Color(0, 0, 1, startOpacity);
        }

        sparkParticles = Instantiate(Resources.Load<ParticleSystem>("sparkParticles"), transform.position, Quaternion.identity) as ParticleSystem;
        sparkParticles.transform.SetParent(transform, false);
    }
	
	// Update is called once per frame
	void Update () {
        if(active) {
            life += Time.deltaTime;
            text.color = new Color(text.color.r, text.color.g, text.color.b, timeout - life);
        }
        if(life >= timeout || health <= 0) {
            word.letters.Remove(this);
            Destroy(gameObject);
        }
    }

    public void Randomize() {
        text.text = word.owner.politeCharacters[(Random.Range(0, word.owner.politeCharacters.Length))];
        if (text.font == word.owner.fonts[2]) text.font = word.owner.fonts[3];
        //Debug.Log(text.font);
    }

    public void OnCollisionEnter2D(Collision2D collision) {

        CharacterController cc = collision.collider.GetComponent<CharacterController>();
        if(cc != null && cc.teamIndex != word.owner.teamIndex) {
            cc.Damage(damage);
            health = 0;
        }

        LetterProjectile hitLetter = collision.collider.GetComponent<LetterProjectile>();
        if(hitLetter != null && hitLetter.word.owner.teamIndex != word.owner.teamIndex) {
            health--;
        }

        if (hitLetter == null) {
            health--;
        }

        sparkParticles.Emit(3);
        sparkParticles.Stop();
    }
}
