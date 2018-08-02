using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_spam : MonoBehaviour {
    public float time;
    public GameObject block;

	private void Start () {
        StartCoroutine(Next_Block());
	}
	
    IEnumerator Next_Block()
    {
        yield return new WaitForSeconds(time);
        Instantiate(block, transform.position, Quaternion.identity);
        StartCoroutine(Next_Block());
    }
}
