﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Rigidbody rigid;
    public float distToGround;
    public GameObject panel;
    public PanelController panelcontroller;
    public GameObject shotPrefab;
    public float dir;
    public float shotCooldown;
    public float enemyCooldown;
    public float enemyCooldownTime;
    public float enemyDir;
    public GameObject enemyPrefab;

    // Use this for initialization
    void Start() {
        rigid = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
        panelcontroller = panel.GetComponent<PanelController>();
        dir = 1;
        shotCooldown = 0;
        enemyCooldown = 2;
        enemyCooldownTime = 2;
        enemyDir = 1;
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
        speed.y = rigid.velocity.y;

        if (Input.GetAxis("Jump") > 0 && IsGrounded()) {
            speed.y = 10;
            panelcontroller.currentCharge -= 0.07f;
        }

        if (Input.GetAxis("Fire3") > 0 && shotCooldown <= 0) {
            GameObject shot = (GameObject)Instantiate(shotPrefab, transform.position + new Vector3(dir, 0, 0), transform.rotation);
            ShotController shotController = shot.GetComponent<ShotController>();
            shotController.dir = dir;

            shotCooldown = 0.1f;
            panelcontroller.currentCharge -= 0.03f;
        }

        rigid.velocity = speed;

        panelcontroller.currentCharge -= Mathf.Abs(speed.x * 0.015f) * Time.deltaTime;

        if (enemyCooldown < 0) {
            enemyCooldownTime /= 1.05f;
            enemyCooldown = enemyCooldownTime;
            GameObject enemy = (GameObject)Instantiate(enemyPrefab, new Vector3(20*enemyDir, 1, 0), transform.rotation);
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.dir = - enemyDir;
            enemyCooldownTime = Mathf.Max(enemyCooldownTime, 0.5f);
            enemyDir = -enemyDir;
        }

        shotCooldown -= Time.deltaTime;
        enemyCooldown -= Time.deltaTime;
	}
}
