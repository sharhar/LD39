using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    public Rigidbody rigidbody;
    public Collider collider;
    public float distToGround;
    public GameObject panel;
    public PanelController panelcontroller;
    public GameObject shotPrefab;
    public float dir;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        distToGround = collider.bounds.extents.y;
        panelcontroller = panel.GetComponent<PanelController>();
        dir = 1;
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
    
	// Update is called once per frame
	void Update () {
        Vector3 speed = new Vector3(Input.GetAxis("Horizontal"), 0, 0) * 5;

        if (speed.x != 0) {
            dir = Mathf.Sign(speed.x);
        }
        speed.y = rigidbody.velocity.y;

        if (Input.GetAxis("Jump") > 0 && IsGrounded()) {
            speed.y = 10;
            panelcontroller.currentCharge -= 0.1f;
        }

        if (Input.GetAxis("Fire3") > 0) {
            GameObject shot = (GameObject)Instantiate(shotPrefab, transform.position + new Vector3(dir, 0, 0), transform.rotation);
            ShotController shotController = shot.GetComponent<ShotController>();
            shotController.dir = dir;
        }

        rigidbody.velocity = speed;

        panelcontroller.currentCharge -= Mathf.Abs(speed.x * 0.025f) * Time.deltaTime;
	}
}
