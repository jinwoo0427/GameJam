using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject startEffect;
    [SerializeField]
    private GameObject endEffect;
    [SerializeField]
    private GameManager game;
    [SerializeField]
    private int stage;
    [SerializeField]
    private ObjectMove objectMove;
    private bool isUse;
    void Start()
    {
        if (stage == 3)
        {
            objectMove = GetComponent<ObjectMove>();
            objectMove.FixSpeed(0.05f);
            return;
        }
        objectMove = GetComponent<ObjectMove>();
        startEffect.SetActive(true);
        StartCoroutine(StartTimer());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" && isUse == false)
        {
            isUse = true;
            Debug.Log("Ãæµ¹");
            StartCoroutine(End());
        }
    }
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(startEffect);
    }
    IEnumerator End()
    {
        if (stage == 3)
        {
            game.Stage3();
        }
        else
        {
            objectMove.FixSpeed(0.05f);
            endEffect.SetActive(true);
            yield return new WaitForSeconds(1f);
            Destroy(endEffect);
            if (stage == 1)
                game.Stage1();
            if (stage == 2)
                game.Stage2();
        }
    }
}
