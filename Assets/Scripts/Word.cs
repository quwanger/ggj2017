using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Word : MonoBehaviour {

    public CharacterController owner;
    public List<LetterProjectile> letters;
    public string word;

    public void Awake() {
        letters = new List<LetterProjectile>();
    }

    public void Update() {
        if (letters.Count <= 0) {
            owner.currentWords.Remove(this);
            Destroy(gameObject);
        }
    }

    public void Fire(float speed) {
        foreach(LetterProjectile letter in letters) {
            letter.GetComponent<Collider2D>().enabled = true;
            letter.GetComponent<Rigidbody2D>().AddForce(letter.transform.up * speed);
            Vector3 pos = letter.transform.position;
            letter.transform.parent = null;
            letter.transform.position = pos;
            letter.active = true;
        }
    }

    public void DestroyLetters() {
        for(int i = letters.Count-1; i >= 0; i--) {
            LetterProjectile letter = letters[i];
            letters.RemoveAt(i);
            Destroy(letter.gameObject);
        }
    }
}
