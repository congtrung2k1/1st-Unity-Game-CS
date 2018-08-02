using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(0.3f, 0.3f, 1f);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        SceneManager.LoadScene("Guide");
    }

    float smooth = 5.0f, rot = 10f;
    int p = 1, pp = 1;

    void Update () {
        transform.position = new Vector3(transform.position.x + p * Time.deltaTime, transform.position.y + pp * Time.deltaTime, 0);

        rot = (rot + 1) % 360f;
        Quaternion target = Quaternion.Euler(0, 0, rot);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "w1") p = -1;
        else if (coll.gameObject.tag == "w2") p = 1;
        else if (coll.gameObject.tag == "w3") pp = -1;
        else if (coll.gameObject.tag == "w4") pp = 1;
    }
}