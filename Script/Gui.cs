using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gui : MonoBehaviour
{
	private void Start () {
        StartCoroutine(GUI());
	}
    IEnumerator GUI()
    {
        yield return new WaitForSeconds(10f);
		SceneManager.LoadScene("Scene");
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Scene");
    }
}
