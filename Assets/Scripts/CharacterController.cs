using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public float moveSpeed = 1;
    public Vector2 maxVelocity;

    public float deadzoneX = 0.01f;
    public float deadzoneY = 0.01f;

    private float joyX = 0.0f;
    private float joyY = 0.0f;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        joyX = Input.GetAxisRaw("Horizontal");
        joyY = Input.GetAxis("Vertical");
        //Debug.Log("Horizontal Input: " + joyX);
        //Debug.Log("Vertical Input: " + joyY);

        if (Mathf.Abs(joyX) > deadzoneX && GetComponent<Rigidbody2D>().velocity.x < maxVelocity.x) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed * joyX, 0.0f));
        } if(Mathf.Abs(joyY) > deadzoneY && GetComponent<Rigidbody2D>().velocity.y < maxVelocity.y) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, moveSpeed * joyY));
        }


        Vector3 diff = transform.position + new Vector3(joyX, joyY, 0) - transform.position;
        diff.Normalize();
        if(diff.magnitude > 0.01f) {
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
        }
	}
}
