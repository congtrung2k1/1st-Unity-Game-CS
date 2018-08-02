using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(5.4f, 5.4f, 0);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(5.5f, 5.5f, 0);
        SceneManager.LoadScene("Scene");
    }
}
