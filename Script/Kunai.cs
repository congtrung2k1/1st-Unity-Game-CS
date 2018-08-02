using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour {
    public GameObject effect;
    private void Update()
    {
        if (transform.position.y < -23) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
            Instantiate(effect, gameObject.transform.position, Quaternion.identity);
        }
    }

}
