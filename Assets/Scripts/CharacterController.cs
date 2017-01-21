using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI; // Required when Using UI elements.

public class CharacterController : MonoBehaviour {

    public int playerIndex;
    public float moveSpeed = 100;
    public int health = 1;
    public GameObject head;

    // Charging
    public Canvas chargeBar;
    public Image charge;
    public float chargeSpeed;
    public float projectileSpeed = 100.0f;
    public Transform headTop;
    public Transform headBottom;
    public float mouthAngle;
    private float timer = 0.0f;
    private bool charging;

    // Controls
    private Vector2 leftJoystick = Vector2.zero;
    private Vector2 rightJoystick = Vector2.zero;

    // Use this for initialization
    void Start () {
        charging = false;
        chargeBar.enabled = false;
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

        GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed * leftJoystick.x, 0.0f));
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, moveSpeed * -leftJoystick.y));
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

    private void Fire()
    {
        // If trigger is held, show the charge bar 
        if (Input.GetAxis("Player" + playerIndex + "Fire1") != 0.0f)
        {
            charging = true;
            timer += Time.deltaTime;
            float chargeAmount = Mathf.Clamp(timer / chargeSpeed, 0.0f, 1.0f);

            Debug.Log(chargeAmount * mouthAngle);

            float topAngle = Mathf.Clamp(chargeAmount * mouthAngle, 0.0f, 40.0f);
            float bottomAngle = Mathf.Clamp(chargeAmount * mouthAngle, 0.0f, 40.0f);

            headTop.localEulerAngles = new Vector3(headTop.localEulerAngles.x, headTop.localEulerAngles.y, topAngle);
            headBottom.localEulerAngles = new Vector3(headBottom.localEulerAngles.x, headBottom.localEulerAngles.y, -bottomAngle);

            //headTop.Rotate(new Vector3(headTop.rotation.x, headTop.rotation.y, maxAngle));
            //headBottom.Rotate(new Vector3(headTop.rotation.x, headTop.rotation.y, -chargeAmount * mouthAngle));

            chargeBar.enabled = true;
            charge.fillAmount = chargeAmount;
        } else if(Input.GetAxis("Player" + playerIndex + "Fire1") == 0 && charging)
        {
            charging = false;
            timer = 0.0f;

            head.transform.rotation = Quaternion.identity;
            headTop.rotation = Quaternion.identity;
            headBottom.rotation = Quaternion.identity;

            chargeBar.enabled = false;
            charge.fillAmount = 0.0f;

            //SpawnProjectile("F");
        }

        
        Debug.Log(charging);
    }

    private void SpawnProjectile(string text) {
        Projectile projectile = (Projectile)Instantiate(Resources.Load<Projectile>("Letter Projectile"), head.transform.position + head.transform.up * -1.5f, Quaternion.identity);
        projectile.text.text = text;
        Vector3 diff = head.transform.up * -1;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        projectile.GetComponent<Rigidbody2D>().AddForce(head.transform.up * -projectileSpeed);
    }

    public void Damage(int damage) {
        health -= damage;
        if (health <= 0) {
            //other player wins!
            Destroy(gameObject);
        }
    }
}
