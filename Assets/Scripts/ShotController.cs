using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

    public float dir;
    public GameObject enemyPrefab;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<EnemyController>() != null) {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(dir*Time.deltaTime*10, 0, 0));

        if (Mathf.Abs(transform.position.x) > 20 || (Mathf.Abs(transform.position.x) < 0.5f && Mathf.Abs(transform.position.y) < 1.5)) {
            Destroy(this.transform.gameObject);
        }
	}
}
