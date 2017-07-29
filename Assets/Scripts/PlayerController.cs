using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject source;
    public Rigidbody rigidbody;
    public Collider collider;
    public float distToGround;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        distToGround = collider.bounds.extents.y;
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 speed = new Vector3(Input.GetAxis("Horizontal"), 0, 0) * 5;

        speed.y = rigidbody.velocity.y;

        if (Input.GetAxis("Vertical") > 0 && IsGrounded()) {
            speed.y = 10;
        }

        rigidbody.velocity = speed;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, source.transform.position - transform.position, out hit)) {
            if (!hit.transform.gameObject.Equals(source)) {
                //Player is in darkness
            } else {
                //Player is in light
            }
        }
	}
}
