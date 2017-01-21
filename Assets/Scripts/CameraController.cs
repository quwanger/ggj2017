using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject player01;
    public GameObject player02;
    public Camera gameCamera;
    public float cameraMoveSpeed;
    public float minSizeY = 5.0f;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        /*float camDistance = Vector2.Distance(player01.transform.position, transform.position);

        if (camDistance > 0.1f)
        {
            Vector2 targetCamDirection = player01.transform.position - transform.position;
            GetComponent<Rigidbody2D>().AddForce(targetCamDirection.normalized * cameraMoveSpeed * camDistance);
        }*/

        if (player01 && player02)
        {
            SetCameraPosition();
            SetCameraSize();
        } else
        {
            float camDistance = Vector2.Distance(player01.transform.position, transform.position);

            if (camDistance > 0.1f)
            {
                Vector2 targetCamDirection = player01.transform.position - transform.position;
                GetComponent<Rigidbody2D>().AddForce(targetCamDirection.normalized * cameraMoveSpeed * camDistance);
            }
        }
    }

    void SetCameraPosition ()
    {
        // Find the position between the two players and divide it by half and set it to that
        Vector3 center = (player01.transform.position + player02.transform.position) * 0.5f;
        this.transform.position = new Vector3(center.x, center.y, this.transform.position.z);
    }

    void SetCameraSize ()
    {
        float minSizeX = minSizeY * Screen.width / Screen.height;

        float distanceX = Mathf.Abs(player01.transform.position.x - player02.transform.position.x) * 0.5f;
        float distanceY = Mathf.Abs(player01.transform.position.y - player02.transform.position.y) * 0.5f;

        float camSizeX = Mathf.Max(distanceX, minSizeX);
        gameCamera.orthographicSize = Mathf.Max(distanceY, camSizeX * Screen.height / Screen.width, minSizeY) + 4.0f;
    }
}
