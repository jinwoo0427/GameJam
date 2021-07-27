using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed);
        if(transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boss")
        {
            collision.transform.GetComponent<Boss>().GetDamage(1);
        }
        if(collision.transform.tag == "Player" || collision.transform.tag == "Attack" || collision.transform.tag == "Ground")
        {
            return;
        }
        Destroy(collision.gameObject);
    }
}
