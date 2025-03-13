using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4.0f;

    void Start()
    {
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
