using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public CameraController cameraController;
    public float dir;

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(-dir, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(dir*Time.deltaTime*2, 0, 0));

        if (cameraController.mode != 2) {
            Destroy(this.gameObject);
        }

        if(Mathf.Abs(transform.position.x) < 1)
        {
            cameraController.mode = 3;
        }
	}
}
