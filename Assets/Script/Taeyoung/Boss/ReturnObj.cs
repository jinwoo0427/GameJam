using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObj : MonoBehaviour
{
    private float speed = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Attack")
        {
            ReturnFunc();
        }
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    public void ReturnFunc()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
        speed = -10;
    }
}