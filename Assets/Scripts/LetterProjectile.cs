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

    public int bounces;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(active) {
            life += Time.deltaTime;
        }
        if(life >= timeout || bounces <= 0) {
            word.letters.Remove(this);
            Destroy(gameObject);
        }
	}

    public void OnCollisionEnter2D(Collision2D collision) {
        
        
        CharacterController cc = collision.collider.GetComponent<CharacterController>();
        if(cc != null) {
            Debug.Log("hit a player!");
            cc.Damage(damage);
        }

        if(collision.collider.GetComponent<LetterProjectile>() == null) {
            bounces--;
        }
    }
}
