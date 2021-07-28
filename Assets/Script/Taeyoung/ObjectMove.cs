using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    private float speed = 0.3f;
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed);
        if (transform.position.x < -10)
            Destroy(gameObject);
    }
    public void FixSpeed(float Speed)
    {
        speed = Speed;
    }
}
