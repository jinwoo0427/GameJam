using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boss")
        {
            collision.GetComponent<Boss>().GetDamage(5);
            return;
        }
        if(collision.transform.tag == "Enemy" || collision.transform.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * 10 * Time.deltaTime);
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
