using UnityEngine;

public class man_move : MonoBehaviour {
    float speed = 0.4f;
    public GameObject effect;
    GameObject ObjMainControll;

    void Start () {
        ObjMainControll = GameObject.FindGameObjectWithTag("GUI_Controll");
    }
	
	void Update () {
        float minx = -11.1f, maxx = 11.1f, miny = -18.3f, maxy = 18.3f;
        float x = transform.position.x;
        float y = transform.position.y;

        if (Input.GetKey(KeyCode.LeftArrow) && x > minx) x -= speed;
        if (Input.GetKey(KeyCode.RightArrow) && x < maxx) x += speed;
        if (Input.GetKey(KeyCode.UpArrow) && y < maxy) y += speed;
        if (Input.GetKey(KeyCode.DownArrow) && y > miny) y -= speed;


        transform.position = new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "cloud")
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            ObjMainControll.GetComponent<MainControll>().End_Game();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "darken" || coll.gameObject.tag == "cloud" || coll.gameObject.tag == "kunai")
            if (gameObject.GetComponent<PolygonCollider2D>().isTrigger)
            {
                ObjMainControll.GetComponent<MainControll>().IsProtect(-1);
            }
            else
            {
                Destroy(gameObject);
                Instantiate(effect, transform.position, Quaternion.identity);
                ObjMainControll.GetComponent<MainControll>().End_Game();
            }

        else

        if (coll.gameObject.tag == "ProNut")
        {
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            ObjMainControll.GetComponent<MainControll>().IsProtect(2);
        }

        else

        if (coll.gameObject.tag == "shot")
        {
            GameObject ObjShot = GameObject.FindGameObjectWithTag("background");
            ObjShot.GetComponent<BulletControll>().IncShot();
        }
    }
}
