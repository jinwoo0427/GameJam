using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject dust;
    [SerializeField]
    private Transform dustPos;
    private SpriteRenderer sprite;
    [SerializeField]
    private float jumpSpeed;
    private bool isGround;
    private int jumpCount;
    private Rigidbody2D rigidbody;
    public float hp;
    [SerializeField]
    private float basicHp;
    [SerializeField]
    private Slider hpSlider;
    [SerializeField]
    private GameObject attackField;
    private bool isAttack;
    private Animator animator;
    private bool isCrouch;
    private bool isJump;
    private Collider2D collider;
    private bool isDead;
    private Vector4 stack;
    [SerializeField]
    private Vector3 Tool;
    [SerializeField]
    private Image image;
    //-------------------------------------------------------------------//
    [SerializeField]
    private GameObject meteo;
    [SerializeField]
    private GameObject fireBall;
    [SerializeField]
    private GameObject heal;
    private bool isGod;
    private bool isShiled;
    [SerializeField]
    private GameObject shiled;
    [SerializeField]
    private Animator attackAnimator;
    [SerializeField]
    private GameObject attackObj;
    [SerializeField]
    private Transform attackPos;
    [SerializeField]
    private GameObject[] wave;
    private bool isWave;
    private int waveCount;
    [SerializeField]
    private AudioSource[] audio;
    private bool isHit;
    [SerializeField]
    private GameObject[] power;
    [SerializeField]
    private Transform[] powerPoint;
    private int count = 0;
    private bool isClear;
    [SerializeField]
    private GameObject[] powerObj;
    private bool isSkill;
    [SerializeField]
    private Text[] amountTxt;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpCount = 0;
        hp = basicHp;
        UpdateUi();
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
        if (collision.transform.tag == "Fire")
        {
            Destroy(collision.gameObject);
            Tool.x++;
            UpdateUi();
        }
        if (collision.transform.tag == "Water")
        {
            Destroy(collision.gameObject);
            Tool.y++;
            UpdateUi();
        }
        if (collision.transform.tag == "Wind")
        {
            Destroy(collision.gameObject);
            Tool.z++;
            UpdateUi();
        }
        if (collision.transform.tag == "Object" && isGod == false)
        {
            if (isHit == true)
                return;
            if(isShiled == true)
            {
                shiled.SetActive(false);
                isShiled = false;
                return;
            }
            audio[2].Play();
            hp--;
            StartCoroutine(Hit());
            UpdateUi();
        }
        if(collision.transform.tag == "Bullet" && isGod == false)
        {
            if (isHit == true)
                return;
            if (isShiled == true)
            {
                isShiled = false;
                return;
            }
            audio[2].Play();
            hp--;
            Destroy(collision.gameObject);
            StartCoroutine(Hit());
            UpdateUi();
        }
    }
    private void Update()
    {
        if(hp >= basicHp)
        {
            hp = basicHp;
        }
        if(image.fillAmount <= 1)
        {
            image.fillAmount += Time.deltaTime * 0.4f;
        }
        if (isGround == true)
        {
            if (jumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) && isCrouch == false)
                {
                    audio[1].Play();
                    rigidbody.velocity = (Vector2.up * jumpSpeed);
                    animator.Play("Jump2");
                    Instantiate(dust, dustPos.position, Quaternion.identity);
                    jumpCount--;
                    if (jumpCount == 1)
                    {
                        animator.Play("Jump1");
                    }
                }
            }
        }
        if(transform.position.y > 3)
        {
            transform.position = new Vector2(-6, 3);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isAttack == false)
        {
            if(isWave == true)
            {
                StartCoroutine(Wave());
                return;
            }
            StartCoroutine(Attack());
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouch = true;
            animator.Play("Slide");
            transform.localScale = new Vector2(1, .5f);
        }
        else
        {
            isCrouch = false;
            transform.localScale = new Vector2(1, 1);
        }
        if(hp <= 0 && isDead == false)
        {
            isDead = true;
            animator.Play("Dead");
            rigidbody.velocity = (Vector2.up * jumpSpeed);
            collider.enabled = false;
        }
        if(stack.w < 2)
        {
            if (Input.GetKeyDown(KeyCode.Q) && Tool.x > 0 && isSkill == false)
            {
                Tool.x--;
                stack.x++;
                stack.w++;
                UpdateUi();
                PowerShow(0, count);
                count++;
            }
            if (Input.GetKeyDown(KeyCode.W) && Tool.y > 0 && isSkill == false)
            {
                Tool.y--;
                stack.y++;
                stack.w++;
                UpdateUi();
                PowerShow(1, count);
                count++;
            }
            if (Input.GetKeyDown(KeyCode.E) && Tool.z > 0 && isSkill == false)
            {
                Tool.z--;
                stack.z++;
                stack.w++;
                UpdateUi();
                PowerShow(2, count);
                count++;
            }
        }
        else
        {
            stack.w = 0;
            StartCoroutine(Skill());
            stack = new Vector4(0, 0, 0, 0);
        }
    }
    IEnumerator Wave()
    {
        if(waveCount == -1) 
        {
            isWave = false;
        }
        else
        {
            Instantiate(wave[waveCount], transform.position, Quaternion.identity);
            audio[5].Play();
            waveCount--;
        }
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator Attack()
    {
        audio[0].Play();
        animator.Play("Attack2");
        image.fillAmount = 0;
        Instantiate(attackObj,attackPos.position,Quaternion.identity);
        isAttack = true;
        attackField.SetActive(true);
        attackAnimator.Play("Attack");
        yield return new WaitForSeconds(0.65f);
        attackField.SetActive(false);
        yield return new WaitForSeconds(2f);
        isAttack = false;
    }
    IEnumerator Skill()
    {
        isSkill = true;
        if(stack.x == 2)
        {
            audio[6].Play();
            Instantiate(fireBall, transform.position, Quaternion.identity);
            Debug.Log("불2 스킬!");
        }
        if(stack.x == 1 && stack.y == 1)
        {
            waveCount = 1;
            isWave = true;
            Debug.Log("불1 + 물1 스킬!");
        }
        if(stack.y == 2)
        {
            audio[3].Play();
            isGod = true;
            shiled.SetActive(true);
            yield return new WaitForSeconds(5f);
            shiled.SetActive(false);
            isGod = false;
            Debug.Log("물2 스킬!");
        }
        if(stack.y == 1 && stack.z == 1)
        {
            audio[3].Play();
            isShiled = true;
            shiled.SetActive(true);
            yield return new WaitForSeconds(5f);
            if(isShiled == true)
            {
                audio[4].Play();
                hp += 2;
                UpdateUi();
            }
            isShiled = false;
            shiled.SetActive(false);
            Debug.Log("물1 + 바람1 스킬!");
        }
        if(stack.z == 2)
        {
            audio[4].Play();
            GameObject A = Instantiate(heal, transform.position, Quaternion.identity);
            A.transform.SetParent(transform);
            hp += 5;
            UpdateUi();
            Debug.Log("바람2 스킬!");
        }
        if(stack.z == 1 && stack.x == 1)
        {
            audio[7].Play();
            Instantiate(meteo, transform.position, Quaternion.identity);
            Debug.Log("불1 + 바람1 스킬!");
        }
        yield return new WaitForSeconds(1f);
        count = 0;
        isClear = true;
        PowerShow();
        isClear = false;
        isSkill = false;
    }
    void UpdateUi()
    {
        hpSlider.value = hp / basicHp;
        amountTxt[0].text = string.Format("{0}", Tool.x);
        amountTxt[1].text = string.Format("{0}", Tool.y);
        amountTxt[2].text = string.Format("{0}", Tool.z);
    }
    public void AddHp(int Hp)
    {
        hp += Hp;
        UpdateUi();
    }
    IEnumerator Hit()
    {
        isHit = true;
        for(int i = 0; i < 5; i++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true   ;
            yield return new WaitForSeconds(0.1f);
        }
        isHit = false;
    }
    void PowerShow(int Power = 0,int Point = 0)
    {
        if (isClear == true)
        {
            Destroy(powerObj[0]);
            Destroy(powerObj[1]);
            return;
        }
        powerObj[Point] = Instantiate(power[Power],powerPoint[Point].position,Quaternion.identity);
        powerObj[Point].transform.SetParent(transform);
    }
}
