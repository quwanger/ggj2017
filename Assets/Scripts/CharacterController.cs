using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public int playerIndex;
    public float moveSpeed = 100;

    private Vector2 leftJoystick = Vector2.zero;
    private Vector2 rightJoystick = Vector2.zero;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Look();
	}

    private void Move() {
        leftJoystick.x = Input.GetAxisRaw("Player"+playerIndex+"MoveX");
        leftJoystick.y = Input.GetAxis("Player"+playerIndex+"MoveY");

        GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed * leftJoystick.x, 0.0f));
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, moveSpeed * -leftJoystick.y));
    }

    private void Look() {
        rightJoystick.x = Input.GetAxisRaw("Player" + playerIndex + "LookX");
        rightJoystick.y = -Input.GetAxis("Player" + playerIndex + "LookY");
        Vector3 diff = transform.position + new Vector3(rightJoystick.x, rightJoystick.y, 0) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);

        Fire();
	}

    void Fire()
    {
        bool charging = false;

        if (Input.GetKey(KeyCode.Space))
        {
            charging = true;

            GetComponent<Animator>().SetTrigger("Firing");
        } else
        {
            charging = false;

            //GetComponent<Animator>().ResetTrigger("Firing");
        }
    }
}
