using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class CharacterController : MonoBehaviour {

    public int playerIndex;
    public int teamIndex;

    public float moveSpeed = 100;
    public int health = 1;
    public GameObject head;

    private Vector2 leftJoystick = Vector2.zero;
    private Vector2 rightJoystick = Vector2.zero;

    //firing
    bool charging = false;
    public float projectileSpeed = 100.0f;

    public float letterDistanceFromPlayer = 3.0f;
    public float letterAngleOfSeperation = 10.0f;
    public float letterScaleInitial = 1.0f;

    public List<Word> currentWords;
    public int maximumAvailableWords = 3;

    // Use this for initialization
    void Start () {
        currentWords = new List<Word>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Look();
        Fire();
    }

    private void Move() {
        leftJoystick.x = Input.GetAxis("Player"+playerIndex+"MoveX");
        leftJoystick.y = Input.GetAxis("Player"+playerIndex+"MoveY");

        GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed * Time.deltaTime * 100 * leftJoystick.x, 0.0f));
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, moveSpeed * Time.deltaTime * 100 * -leftJoystick.y));
    }

    private void Look() {
        rightJoystick.x = Input.GetAxis("Player" + playerIndex + "LookX");
        rightJoystick.y = -Input.GetAxis("Player" + playerIndex + "LookY");
        Vector3 diff = transform.position + new Vector3(rightJoystick.x, rightJoystick.y, 0) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        head.transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);

        Debug.DrawRay(head.transform.position, transform.up * -10, Color.red);
	}

    void Fire()
    {
        //Debug.Log(Input.GetAxis(("Player" + playerIndex + "Fire1")));
        if (currentWords.Count <= maximumAvailableWords && Input.GetAxis("Player"+playerIndex+"Fire1") != 0.0f && !charging)
        {
            charging = true;
            GetComponent<Animator>().SetTrigger("Firing");
            CreateWord(PickRandomWord(1));
        } else if(Input.GetAxis("Player"+playerIndex+"Fire1") == 0 && charging)
        {
            currentWords[currentWords.Count - 1].Fire(projectileSpeed);
            charging = false;
            //GetComponent<Animator>().ResetTrigger("Firing");
        }

        if (charging) {
            int count = 0;
            foreach (LetterProjectile letter in currentWords[currentWords.Count - 1].letters) {
                UpdateLetterTransform(letter, count, currentWords[currentWords.Count-1].word);
                count++;
            }
        }
    }

    public string PickRandomWord(int chargeLevel) {
        int numOfAvailableWords;
        try {
            switch (chargeLevel) {
                case 1:
                    numOfAvailableWords = System.Enum.GetNames(typeof(EnglishWords.ShortWords)).Length;
                    return ((EnglishWords.ShortWords)Random.Range(0, numOfAvailableWords)).ToString().ToUpper();
                case 2:
                    numOfAvailableWords = System.Enum.GetNames(typeof(EnglishWords.MediumWords)).Length;
                    return ((EnglishWords.MediumWords)Random.Range(0, numOfAvailableWords)).ToString().ToUpper();
                case 3:
                    numOfAvailableWords = System.Enum.GetNames(typeof(EnglishWords.LongWords)).Length;
                    return ((EnglishWords.LongWords)Random.Range(0, numOfAvailableWords)).ToString().ToUpper();
            }
        } catch {
            return "Sorry!";
        }
        return "Sorry!";
    }

    private void CreateWord(string word) {
        char[] letters = word.ToCharArray();
        GameObject obj = (GameObject)Instantiate(new GameObject(), transform);
        Word currentWord = obj.AddComponent<Word>();
        currentWord.owner = this;
        currentWord.word = word;
        currentWords.Add(currentWord);

        int count = 0;

        foreach (char letter in letters) {
            LetterProjectile projectile = (LetterProjectile)Instantiate(Resources.Load<LetterProjectile>("Letter Projectile"), head.transform.position, Quaternion.identity);
            //projectile.transform.SetParent(transform);
            projectile.word = currentWord;
            //text
            projectile.text.text = letter.ToString();

            UpdateLetterTransform(projectile, count, word);
            
            projectile.GetComponent<Collider2D>().enabled = false;
            currentWord.letters.Add(projectile);
            Debug.Log("ADDED " + letter + " TO " + word);
            count++;
        }
    }

    private void UpdateLetterTransform(LetterProjectile projectile, int count, string word) {
        //angle
        Vector3 diff = head.transform.up * -1;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        float rotationOffset = letterAngleOfSeperation * letterScaleInitial * count - letterAngleOfSeperation * word.Length * 0.5f;
        projectile.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90 - rotationOffset);

        //position
        projectile.transform.position = head.transform.position + projectile.transform.up * letterDistanceFromPlayer * letterScaleInitial;

        //scale
        projectile.transform.localScale = projectile.transform.localScale * letterScaleInitial;
    }

    public void Damage(int damage) {
        health -= damage;
        if (health <= 0) {
            //other player wins!
            //Destroy(gameObject);
        }
    }
}
