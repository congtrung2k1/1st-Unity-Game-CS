using UnityEngine;

public class DarkenControll : MonoBehaviour
{
    private Animator Ani;
    public GameObject kunai;
    public GameObject effect;

    private void Start()
    {
        Ani = gameObject.GetComponent<Animator>();
        int t = Random.Range(0, 2);
        if (t == 0) Ani.SetBool("Next", false); else Ani.SetBool("Next", true);
    }

    float timeLate = 0.65f;
    float nextTime = 0f;
    bool IN = false;
    float speed = 0.3f;
    int p = 1, pp = -1;
    float minx = -11.1f, maxx = 11.1f, miny = 0f, maxy = 18.6f;

    void Update () {
        float x = transform.position.x;
        float y = transform.position.y;

        if (!IN) x += speed; else
            if (x + p * speed <= maxx) x += p * speed;
            else
            {
                p = -1;
                int t = Random.Range(0, 2);
                if (t == 0) Ani.SetBool("Next", false); else Ani.SetBool("Next", true);
            }
        if (y + pp * speed >= miny) y += pp * speed;
        else
        {
            pp = 1;
            int t = Random.Range(0, 2);
            if (t == 0) Ani.SetBool("Next", false); else Ani.SetBool("Next", true);
        }
        if (y + pp * speed <= maxy) y += pp * speed;
        else
        {
            pp = -1;
            int t = Random.Range(0, 2);
            if (t == 0) Ani.SetBool("Next", false); else Ani.SetBool("Next", true);
        }

        transform.position = new Vector2(x, y);

        if (x >= 0) IN = true;
        if (IN && x < minx) Destroy(gameObject);

        if (Time.time > nextTime)
        {
            nextTime = Time.time + timeLate;
            Instantiate(kunai, gameObject.transform.position, Quaternion.identity);
        }
    }

    int heal = 2;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            heal--;
            if (heal == 0)
            {
                Destroy(gameObject);
                GameObject ObjMainControll = GameObject.FindGameObjectWithTag("GUI_Controll");
                ObjMainControll.GetComponent<MainControll>().Inc(5);
                Instantiate(effect, gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
