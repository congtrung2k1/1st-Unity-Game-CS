using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 1.5f;
    public Vector3 target;
    float minx = -13.1f, maxx = 12.7f, miny = -22f, maxy = 22f;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update () {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed);

        if (transform.position.x <= minx || maxx <= transform.position.x)
        {
            float x = (-target.x - transform.position.x) * 10f;
            float y = (target.y - transform.position.x) * 10f;
            target = new Vector3(x, y, 0);
        }
        if (transform.position.y <= miny)
        {
            float x = (target.x - transform.position.x) * 10f;
            float y = (-target.y - transform.position.y) * 10f;
            target = new Vector3(x, y, 0);
        }
            
        if (transform.position.y >= maxy) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "darken" || coll.gameObject.tag == "cloud" || coll.gameObject.tag == "kunai")
        {
            Destroy(gameObject);
        }
    }
}
