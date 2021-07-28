using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bullet;
    [SerializeField]
    private float[] coolTime;
    [SerializeField]
    private float hp;
    private Animator animator;
    [SerializeField]
    private Transform[] firePos;
    [SerializeField]
    private GameObject plag;
    private bool isSpawn;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float basicHP;
    [SerializeField]
    private AudioSource audio;
    void Start()
    {
        animator = GetComponent<Animator>();
        hp = basicHP;
        UpdateUI();
        StartCoroutine(Skill());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "BossAttackWave")
        {
            hp -= collision.GetComponent<Damage>().damage;
            UpdateUI();
            Destroy(collision.gameObject);
        }
    }
    void Update()
    {
        if(hp <= 0 && isSpawn == false)
        {
            isSpawn = true;
            plag.SetActive(true);
            animator.Play("Dead");
            audio.Play();
        }
    }
    public void GetDamage(int Damage)
    {
        hp -= Damage;
        UpdateUI();
    }
    void UpdateUI()
    {
        slider.value = hp / basicHP;
    }
    IEnumerator Skill()
    {
        while (isSpawn == false)
        {
            switch (Random.Range(0, 5))
            {
                case 0://총알 : 5개 위치 : 2개
                    for (int i = 0; i < 4; i++)
                    {
                        int A = Random.Range(0, 6);
                        int B = Random.Range(0, 3);
                        Instantiate(bullet[A], firePos[B].position, Quaternion.identity);
                        yield return new WaitForSeconds(coolTime[0]);
                    }
                    break;
                case 1://총알 3개 위치 1개
                    for(int i = 0; i < 6; i++)
                    {
                        int A = Random.Range(6, 9);
                        int B = Random.Range(2, 3);
                        Instantiate(bullet[A], firePos[B].position, Quaternion.identity);
                        yield return new WaitForSeconds(coolTime[1]);
                    }
                    break;
                case 2://총알 1개 위치 3개
                    for(int i = 0; i < 10; i++)
                    {
                        int B = Random.Range(3, 6);
                        Instantiate(bullet[9],firePos[B]);
                        yield return new WaitForSeconds(coolTime[2]);
                    }
                    break;
                case 3:
                    for(int i = 0; i < 4; i++)
                    {
                        Instantiate(bullet[10], firePos[6]);
                        yield return new WaitForSeconds(coolTime[3]);
                    }
                    break;
                case 4:
                    for(int i = 0; i < 6; i++)
                    {
                        Instantiate(bullet[11], firePos[7]);
                        yield return new WaitForSeconds(coolTime[3]);
                    }
                    yield return new WaitForSeconds(coolTime[4]);
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
