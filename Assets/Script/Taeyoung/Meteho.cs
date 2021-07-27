using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteho : MonoBehaviour
{
    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector2(1,-1) * 10 * Time.deltaTime);
        if(transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Object" || collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            player.AddHp(1);
        }
    }
}
