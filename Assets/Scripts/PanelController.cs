using UnityEngine;
using System.Collections;

public class PanelController : MonoBehaviour {

    public GameObject source;
    public GameObject charge;

    public float currentCharge = 1;
    public float time = 0;

    // Use this for initialization
    void Start () {

	}

    void SetCharge(float chrg)
    {
        charge.transform.localScale = new Vector3(chrg, 1, 1);
        charge.transform.localPosition = new Vector3(chrg / 2 - 0.5f, 0, 0);
    }

    // Update is called once per frame
    void Update () {
        Vector3 diff = this.transform.position - source.transform.position;

        float angle = Mathf.Atan2(diff.y, diff.x);

        this.transform.eulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg + 90);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, source.transform.position - transform.position, out hit))
        {
            if (hit.transform.gameObject.Equals(source))
            {
                currentCharge += 2 * Time.deltaTime;
            }
        }

        currentCharge = Mathf.Clamp(currentCharge, 0, 1);

        SetCharge(currentCharge);
    }
}
