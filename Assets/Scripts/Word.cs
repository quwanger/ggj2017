using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Word {

    public List<LetterProjectile> letters;
    public string word;

    public Word(string word) {
        this.word = word;
        letters = new List<LetterProjectile>();
    }

    public void Fire(float speed) {
        
        foreach(LetterProjectile letter in letters) {
            letter.GetComponent<Collider2D>().enabled = true;
            letter.GetComponent<Rigidbody2D>().AddForce(letter.transform.up * speed);
            Vector3 pos = letter.transform.position;
            letter.transform.parent = null;
            letter.transform.position = pos;
        }
    }
}
