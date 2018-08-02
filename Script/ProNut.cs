using UnityEngine;

public class ProNut : MonoBehaviour
{
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        transform.position = new Vector2(x, y - 0.3f);
        if (y < -30.6f) Destroy(gameObject);

        transform.Rotate(Vector3.back);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "man") Destroy(gameObject);
    }
}
