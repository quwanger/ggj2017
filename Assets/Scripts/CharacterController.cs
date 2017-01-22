using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI; // Required when Using UI elements.
using System.Linq;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {

    public int playerIndex;
    public int teamIndex;

    public float moveSpeed = 100;
    public GameObject head;

    // Charging
    public Canvas chargeBar;
    public Image charge;
    public float chargeSpeed;
    public Transform headTop;
    public Transform headBottom;
    public float mouthAngle;
    private float timer = 0.0f;
    
    public float chargeLevel1;
    public float chargeLevel2;

    // Health
    public float health;
    private float maxHealth;
    public Image healthBar;

    //firing
    public float projectileSpeed = 100.0f;
    private bool charging;
    public float letterDistanceFromPlayer = 3.0f;
    public float letterOffsetBackFromPlayer = 3.0f;
    public float letterAngleOfSeperation = 10.0f;
    public float letterScaleInitial = 1.0f;
    private float letterScaleTarget = 1.0f;
    public float letterScaleMultiplier = 0.5f;

    public List<Word> currentWords;
    public int maximumAvailableWords = 3;

    // Controls
    private Vector2 leftJoystick = Vector2.zero;
    private Vector2 rightJoystick = Vector2.zero;
    
    //text & fonts
    List<Font> fonts;

    // Sounds
    private SoundManager soundManager;

    private bool gameOver;

    // Use this for initialization
    void Start () {
        currentWords = new List<Word>();
        charging = false;
        chargeBar.enabled = false;

        fonts = new List<Font>();
        fonts.Add(Resources.Load<Font>(Path.Combine("Fonts", "murkybuzzDEMO")));
        fonts.Add(Resources.Load<Font>(Path.Combine("Fonts", "deathrattlebb_reg")));
        fonts.Add(Resources.Load<Font>(Path.Combine("Fonts", "Devastated")));
        
        maxHealth = health;
        gameOver = false;

        soundManager = FindObjectOfType<SoundManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            Invoke("LoadMenu", 5);
        } else
        {
            Move();
            Look();
            Fire();
        }
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
        head.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        Debug.DrawRay(head.transform.position, transform.up * -10, Color.red);
	}

    private bool level1Reached = false;
    private bool level2Reached = false;
    private int chargeLevel = 0;

    void Fire()
    {
        //Debug.Log(Input.GetAxis(("Player" + playerIndex + "Fire1")));
        if (currentWords.Count < maximumAvailableWords && Input.GetAxis("Player" + playerIndex + "Fire1") != 0.0f)
        {
            timer += Time.deltaTime;
            float chargeAmount = Mathf.Clamp(timer / chargeSpeed, 0.0f, 1.0f);
            chargeLevel = (int)(chargeAmount * 2.0f) + 1;
            if (!charging) {
                CreateWord(PickRandomWord(chargeLevel), chargeLevel);
            } else if (chargeAmount >= chargeLevel1 && !level1Reached) {
                Word w = currentWords.Last();
                currentWords.Remove(currentWords.Last());
                w.DestroyLetters();
                Destroy(w.gameObject);
                CreateWord(PickRandomWord(chargeLevel), chargeLevel);
                level1Reached = true;
            } else if (chargeAmount >= chargeLevel2 && !level2Reached) {
                Word w = currentWords.Last();
                currentWords.Remove(currentWords.Last());
                w.DestroyLetters();
                Destroy(w.gameObject);
                CreateWord(PickRandomWord(chargeLevel), chargeLevel);
                level2Reached = true;
            }

            charging = true;

            float topAngle = Mathf.Clamp(chargeAmount * mouthAngle, 0.0f, 40.0f);
            float bottomAngle = Mathf.Clamp(chargeAmount * mouthAngle, 0.0f, 40.0f);

            headTop.localEulerAngles = new Vector3(headTop.localEulerAngles.x, headTop.localEulerAngles.y, topAngle);
            headBottom.localEulerAngles = new Vector3(headBottom.localEulerAngles.x, headBottom.localEulerAngles.y, -bottomAngle);

            //headTop.Rotate(new Vector3(headTop.rotation.x, headTop.rotation.y, maxAngle));
            //headBottom.Rotate(new Vector3(headTop.rotation.x, headTop.rotation.y, -chargeAmount * mouthAngle));

            chargeBar.enabled = true;
            charge.fillAmount = chargeAmount;
            charge.color = new Color32(255, 255, 225, 100);

            //swap fonts/scale text
            Font targetFont = fonts[0];
            letterScaleTarget = letterScaleInitial + chargeAmount * letterScaleMultiplier;
            if (chargeAmount >= chargeLevel1) {
                targetFont = fonts[1];
            }
            if(chargeAmount >= chargeLevel2) {
                targetFont = fonts[2];
            }
            foreach (LetterProjectile letter in currentWords.Last().letters) {
                letter.text.font = targetFont;
                //(letter.text.transform as RectTransform).localScale = Vector3.one * letterScaleTarget;
            }

        } else if (Input.GetAxis("Player" + playerIndex + "Fire1") == 0 && charging)
        {
            charging = false;
            timer = 0.0f;

            level1Reached = false;
            level2Reached = false;

            head.transform.rotation = Quaternion.identity;
            headTop.rotation = Quaternion.identity;
            headBottom.rotation = Quaternion.identity;

            chargeBar.enabled = false;
            charge.fillAmount = 0.0f;

            //currentWords[currentWords.Count - 1].Fire(projectileSpeed);
            soundManager.PlaySound(currentWords.Last().word);
            currentWords[currentWords.Count - 1].Fire(projectileSpeed * (chargeLevel*0.4f));
            chargeLevel = 0;
        }

        if (charging)
        {
            int count = 0;
            foreach (LetterProjectile letter in currentWords[currentWords.Count - 1].letters)
            {
                UpdateLetterTransform(letter, count, currentWords[currentWords.Count - 1].word);
                count++;
            }
        }

    }

    public string PickRandomWord(int chargeLevel) {
        int numOfAvailableWords;
        string wordToReturn = "null";
        if(teamIndex == 0) {
            try {
                switch (chargeLevel) {
                    case 1:
                        numOfAvailableWords = System.Enum.GetNames(typeof(EnglishWords.ShortWords)).Length;
                        wordToReturn = ((EnglishWords.ShortWords)Random.Range(0, numOfAvailableWords)).ToString();
                        break;
                    case 2:
                        numOfAvailableWords = System.Enum.GetNames(typeof(EnglishWords.MediumWords)).Length;
                        wordToReturn = ((EnglishWords.MediumWords)Random.Range(0, numOfAvailableWords)).ToString();
                        break;
                    case 3:
                        numOfAvailableWords = System.Enum.GetNames(typeof(EnglishWords.LongWords)).Length;
                        wordToReturn = ((EnglishWords.LongWords)Random.Range(0, numOfAvailableWords)).ToString();
                        break;
                }
            }
            catch {
                wordToReturn = "Sorry";
            }
        } else if(teamIndex == 1) {
            try {
                switch (chargeLevel) {
                    case 1:
                        numOfAvailableWords = System.Enum.GetNames(typeof(FrenchWords.ShortWords)).Length;
                        wordToReturn = ((FrenchWords.ShortWords)Random.Range(0, numOfAvailableWords)).ToString();
                        break;
                    case 2:
                        numOfAvailableWords = System.Enum.GetNames(typeof(FrenchWords.MediumWords)).Length;
                        wordToReturn = ((FrenchWords.MediumWords)Random.Range(0, numOfAvailableWords)).ToString();
                        break;
                    case 3:
                        numOfAvailableWords = System.Enum.GetNames(typeof(FrenchWords.LongWords)).Length;
                        wordToReturn = ((FrenchWords.LongWords)Random.Range(0, numOfAvailableWords)).ToString();
                        break;
                }
            }
            catch {
                wordToReturn = "Désolé";
            }
        }

        wordToReturn = wordToReturn.Replace("_", " ");
        return wordToReturn;
    }

    private void CreateWord(string word, float projectileLevel) {
        char[] letters = word.ToCharArray();
        GameObject obj = (GameObject)Instantiate(new GameObject());

        Word currentWord = obj.AddComponent<Word>();
        currentWord.owner = this;
        currentWord.word = word;
        currentWords.Add(currentWord);

        int count = 0;

        foreach (char letter in letters) {
            LetterProjectile projectile = (LetterProjectile)Instantiate(Resources.Load<LetterProjectile>("Letter Projectile"), head.transform.position, Quaternion.identity);

            //projectile.transform.SetParent(transform);
            projectile.word = currentWord;
            projectile.damage = projectileLevel;
            projectile.health = projectileLevel;

            //text
            projectile.text.text = letter.ToString();

            UpdateLetterTransform(projectile, count, word);
            
            projectile.GetComponent<Collider2D>().enabled = false;
            currentWord.letters.Add(projectile);

            count++;
        }
    }

    private void UpdateLetterTransform(LetterProjectile projectile, int count, string word) {
        //angle
        Vector3 diff = head.transform.up * -1;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        float rotationOffset = letterAngleOfSeperation * letterScaleTarget * count - letterAngleOfSeperation * word.Length * 0.5f;
        projectile.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - rotationOffset);

        //position
        projectile.transform.position = head.transform.position - head.transform.right * -letterOffsetBackFromPlayer + projectile.transform.up * letterDistanceFromPlayer * letterScaleTarget;

        //scale
        projectile.transform.localScale = Vector3.one * 0.01f * letterScaleTarget;
    }

    public void Damage(float damage) {
        health -= damage;

        Debug.Log(health);

        healthBar.fillAmount = health / maxHealth;

        if (health <= 0) {
            //other player wins!
            //Destroy(gameObject);

            gameOver = true;
        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
