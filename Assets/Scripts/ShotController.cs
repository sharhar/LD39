using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {

    public float dir;
    public GameObject enemyPrefab;
    public PlayerController playerController;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<EnemyController>() != null) {
            playerController.gameObject.GetComponent<AudioSource>().Play();

            Destroy(other.gameObject);
            Destroy(this.gameObject);
            
            playerController.score++;

            playerController.text.text = "Score: " + playerController.score;
        }
    }

    // Use this for initialization
    void Start () {
        playerController = Camera.main.GetComponent<CameraController>().gameInst.GetComponentInChildren<PlayerController>();
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(dir*Time.deltaTime*10, 0, 0));

        if (Mathf.Abs(transform.position.x) > 20 || (Mathf.Abs(transform.position.x) < 0.5f && Mathf.Abs(transform.position.y) < 1.5)) {
            Destroy(this.transform.gameObject);
        }
	}
}
