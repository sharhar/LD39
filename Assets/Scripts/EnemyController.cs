using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float dir;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(dir*Time.deltaTime*2, 0, 0));
	}
}
