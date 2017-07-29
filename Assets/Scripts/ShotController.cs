using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

    public float dir;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(dir*Time.deltaTime*10, 0, 0));

        if (Mathf.Abs(transform.position.x) > 20) {
            Destroy(this.transform.gameObject);
        }
	}
}
