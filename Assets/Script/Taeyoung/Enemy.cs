using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float rpm;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private GameObject bullet;
    private bool isShoot;
    void Start()
    {

    }
    void Update()
    {
        if(transform.position.x < 10 && isShoot == false)
        {
            isShoot = true;
            StartCoroutine(Shoot());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Attack")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(rpm);
        }
    }
}