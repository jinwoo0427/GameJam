using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Update()
    {
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed);
    }
}
