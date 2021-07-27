using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWave : MonoBehaviour
{
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy" || collision.transform.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
        if(collision.transform.tag == "Attack")
        {
            SubWave col = transform.GetChild(0).GetComponent<SubWave>();
            col.Turn();
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * 10 * Time.deltaTime);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
