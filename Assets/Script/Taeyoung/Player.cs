using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed;
    private bool isGround;
    private int jumpCount;
    private Rigidbody2D rigidbody;
    private float hp;
    [SerializeField]
    private float basicHp;
    [SerializeField]
    private Slider hpSlider;
    [SerializeField]
    private GameObject attackField;
    private bool isAttack;
    private Animator animator;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpCount = 0;

        hp = basicHp;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = true;
            animator.Play("Playermove");
            jumpCount = 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Object")
        {
            hp--;
            UpdateUi();
        }
        if(collision.transform.tag == "Bullet")
        {
            hp--;
            Destroy(collision.gameObject);
            UpdateUi();
        }
    }
    private void Update()
    {
        if (isGround == true)
        {
            if (jumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rigidbody.velocity = (Vector2.up * jumpSpeed);
                    animator.Play("Jump2");
                    jumpCount--;
                    if (jumpCount == 1)
                        animator.Play("Jump1");
                }
            }
        }
        if(transform.position.y > 3)
        {
            transform.position = new Vector2(-6, 3);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isAttack == false)
        {
            StartCoroutine(Attack());
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
    IEnumerator Attack()
    {
        isAttack = true;
        attackField.SetActive(true);
        yield return new WaitForSeconds(1f);
        attackField.SetActive(false);
        isAttack = false;   
    }
    void UpdateUi()
    {
        hpSlider.value = hp / basicHp;
    }
}
