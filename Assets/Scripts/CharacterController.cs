using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class CharacterController : MonoBehaviour {

    public int playerIndex;
    public float moveSpeed = 100;
    public int health = 1;
    public GameObject head;

    private Vector2 leftJoystick = Vector2.zero;
    private Vector2 rightJoystick = Vector2.zero;

    //firing
    bool charging = false;
    public float projectileSpeed = 100.0f;
    public List<Word> currentWords;

    private Vector3 lastPosition;
    private Vector3 deltaPosition;
    private Vector3 lastRotation;
    private Vector3 deltaRotation;


    // Use this for initialization
    void Start () {
        currentWords = new List<Word>();
	}
	
	// Update is called once per frame
	void Update () {
        deltaPosition = transform.position - lastPosition;
        deltaRotation = transform.rotation.eulerAngles - lastRotation;

        Move();
        Look();
        Fire();

        lastPosition = transform.position;
        lastRotation = transform.rotation.eulerAngles;
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
        if (Input.GetAxis("Player"+playerIndex+"Fire1") != 0.0f && !charging)
        {
            charging = true;
            GetComponent<Animator>().SetTrigger("Firing");
            ChargeWord("ASSHOLES");
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

    public float letterDistanceFromPlayer = 3.0f;
    public float letterAngleOfSeperation = 10.0f;
    public float letterScaleInitial = 1.0f;

    private void ChargeWord(string word) {
        char[] letters = word.ToCharArray();
        Word currentWord = new Word(word);
        currentWords.Add(currentWord);

        int count = 0;

        foreach (char letter in letters) {
            LetterProjectile projectile = (LetterProjectile)Instantiate(Resources.Load<LetterProjectile>("Letter Projectile"), head.transform.position, Quaternion.identity);
            projectile.transform.SetParent(transform);
            //text
            projectile.text.text = letter.ToString();

            UpdateLetterTransform(projectile, count, word);

            //float letterSpacing = 1.0f;
            //float wordLength = letterSpacing * word.Length;
            //float halfWordLength = wordLength * 0.5f;
            //projectile.transform.position = projectile.transform.position - projectile.transform.right * halfWordLength + projectile.transform.right * letterSpacing * count;

            projectile.GetComponent<Collider2D>().enabled = false;
            currentWord.letters.Add(projectile);
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
