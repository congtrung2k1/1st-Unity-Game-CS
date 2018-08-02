using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cloud_dis : MonoBehaviour {
    public List<GameObject> block;

    GameObject obj;

    bool scored = false;
    float speed = 0.3141f;
    float limit = -30.6f;

    void Start () {
        if (obj == null)
        {
            obj = GameObject.FindGameObjectWithTag("GUI_Controll");
        }

        int dem = 0;
        for (var i = 0; i < block.Count; i++)
        {
            int p = Random.Range(0, 2);
            if (p == 1)
            {
                block[i].SetActive(false);
                dem++;
            }
        }
        if (dem == 0)
        {
            int p = Random.Range(0, block.Count);
            block[p].SetActive(false);
        }
	}
	
	void Update () {
        float x = transform.position.x;
        float y = transform.position.y;
        transform.position = new Vector2(x, y - speed);

        if (y < limit) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "man" && !scored)
        {
            scored = true;
            obj.GetComponent<MainControll>().Inc(1);
        }
    }

    public void IncSpeed()
    {
        speed += 0.05f;
    }
}
