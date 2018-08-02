using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControll : MonoBehaviour
{
    GameObject ObjMan;
    void Start()
    {
         ObjMan = GameObject.FindGameObjectWithTag("man");
    }
    void Update()
    {
        transform.position = new Vector2(ObjMan.transform.position.x - 0.28f, ObjMan.transform.position.y);
    }
}
