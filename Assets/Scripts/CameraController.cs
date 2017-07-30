using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject startText;
    public GameObject loseTextPrefab;
    public GameObject loseText = null;
    public GameObject gamePrefab;
    public GameObject gameInst;

    public float loseCooldown = 0;

    public int mode = 0;

    // Use this for initialization
    void Start()
    {
        float targetaspect = 4.0f / 3.0f;

        float windowaspect = (float)Screen.width / (float)Screen.height;

        float scaleheight = windowaspect / targetaspect;

        Camera camera = GetComponent<Camera>();

        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.anyKeyDown && mode < 2 && loseCooldown <= 0) {
            if (mode == 0)
            {
                Destroy(startText);
            }
            else {
                Destroy(loseText);
                loseText = null;
            }

            gameInst = (GameObject)Instantiate(gamePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            mode = 2;
        }

        if (mode == 3) {
            if (gameInst != null) {
                int score = gameInst.GetComponentInChildren<PlayerController>().score;
                Destroy(gameInst);
                gameInst = null;
                if (loseText == null)
                {
                    loseText = (GameObject)Instantiate(loseTextPrefab);
                    Text text = loseText.GetComponentInChildren<Text>();
                    text.text = text.text + score;
                }
            }
            mode = 1;
            loseCooldown = 2;
        }

        loseCooldown -= Time.deltaTime;

    }
}
