using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{
    int shot = 3;
    public GameObject bullet;
    GameObject ObjMainControll, ObjMan;
    float timeLate = 0.2f;
    float nextTime = 0f;

    private void Start()
    {
        ObjMan = GameObject.FindGameObjectWithTag("man");
        ObjMainControll = GameObject.FindGameObjectWithTag("GUI_Controll");
    }

    public void IncShot()
    {
        shot += 5;
        ObjMainControll.GetComponent<MainControll>().IsReload(shot);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && shot > 0 && Time.time > nextTime && ObjMan != null)
        {
            shot--;
            nextTime = Time.time + timeLate;
            ObjMainControll.GetComponent<MainControll>().IsReload(shot);

            GameObject ObjBullet = (GameObject)Instantiate(bullet, ObjMan.transform.position, Quaternion.identity);
            float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - ObjMan.transform.position.x;
            float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - ObjMan.transform.position.y;
            ObjBullet.GetComponent<Bullet>().target = new Vector3(x * 10f, y * 10f, 0);
        }
    }
}
