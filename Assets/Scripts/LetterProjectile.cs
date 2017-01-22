using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LetterProjectile : MonoBehaviour {

    public Word word;
    public Text text;
    public float damage = 1;

    public bool active = false;
    public float life = 0.0f;
    public float timeout = 5.0f;

    public float health = 1;

	// Use this for initialization
	void Start () {
	    if(word.owner.teamIndex == 0) {
            text.color = Color.red;
        } else if(word.owner.teamIndex == 1) {
            text.color = Color.blue;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(active) {
            life += Time.deltaTime;
        }
        if(life >= timeout || health <= 0) {
            word.letters.Remove(this);
            Destroy(gameObject);
        }
	}

    public void OnCollisionEnter2D(Collision2D collision) {

        CharacterController cc = collision.collider.GetComponent<CharacterController>();
        if(cc != null && cc.teamIndex != word.owner.teamIndex) {
            cc.Damage(damage);
        }

        LetterProjectile hitLetter = collision.collider.GetComponent<LetterProjectile>();
        if(hitLetter != null && hitLetter.word.owner.teamIndex != word.owner.teamIndex) {
            health--;
        }

        if (hitLetter == null) {
            health--;
        }
    }
}
