using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent : MonoBehaviour {
    public GameObject shieldTalent;
    public GameObject shotTalent;

	private void Start () {
        StartCoroutine(Spam());
    }
    IEnumerator Spam()
    {
        yield return new WaitForSeconds(3.14159f);
        int p = Random.Range(0, 2);
        if (p == 1)
        {
            p = Random.Range(0, 2);
            if (p == 1)
            {
                p = Random.Range(0, 2);
                Vector2 pos = new Vector2(Random.Range(-11, 11), transform.position.y);
                if (p == 0) Instantiate(shieldTalent, pos, Quaternion.identity);
                else Instantiate(shotTalent, pos, Quaternion.identity);
            }
        }
        StartCoroutine(Spam());
    }

}