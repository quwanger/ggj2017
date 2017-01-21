using UnityEngine;
using System.Collections;
using System.IO;

public class CharacterController : MonoBehaviour {

    public int playerIndex;
    public float moveSpeed = 100;
    public int health = 1;

    private Vector2 leftJoystick = Vector2.zero;
    private Vector2 rightJoystick = Vector2.zero;

    // Use this for initialization
    void Start () {

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
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);

        Debug.DrawRay(transform.position, transform.up * -10, Color.red);
	}

    bool charging = false;
    public float projectileSpeed = 100.0f;

    void Fire()
    {
        if (Input.GetButton("Player"+playerIndex+"Fire1"))
        {
            charging = true;
            GetComponent<Animator>().SetTrigger("Firing");
        } else if(Input.GetButtonUp("Player"+playerIndex+"Fire1"))
        {
            SpawnProjectile("F");
            charging = false;
            //GetComponent<Animator>().ResetTrigger("Firing");
        }
    }

    private void SpawnProjectile(string text) {
        Projectile projectile = (Projectile)Instantiate(Resources.Load<Projectile>("Letter Projectile"), transform.position + transform.up * -1.5f, Quaternion.identity);
        projectile.text.text = text;
        Vector3 diff = transform.up * -1;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * -projectileSpeed);
    }

    public void Damage(int damage) {
        health -= damage;
        if (health <= 0) {
            //other player wins!
            Destroy(gameObject);
        }
    }
}
