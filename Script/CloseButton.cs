using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButton : MonoBehaviour
{
    public GameObject endAnimation;

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(2.9f, 2.9f, 0f);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(3f, 3f, 0);
        StartCoroutine(CallWait());
    }

    IEnumerator CallWait()
    {
        endAnimation.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("begin");
    }

}
