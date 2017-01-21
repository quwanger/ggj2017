using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Projectile : MonoBehaviour {

    public Text text;
    public int damage = 1;

    public float life = 0.0f;
    public float timeout = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        life += Time.deltaTime;
        if(life >= timeout) {
            Destroy(gameObject);
        }
	}

    public void OnCollisionEnter2D(Collision2D collision) {
        CharacterController cc = collision.collider.GetComponent<CharacterController>();
        if(cc != null) {
            Debug.Log("hit!");
            cc.Damage(damage);
        }
    }
}
