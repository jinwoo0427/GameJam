using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGive : MonoBehaviour
{
    [SerializeField]
    private GameObject[] item;
    [SerializeField]
    private Transform[] itemPos;
    private int a;
    private int b;
    void Start()
    {
        StartCoroutine(Give());
    }
    IEnumerator Give()
    {
        while (true)
        {
            a = Random.Range(0, 3);
            b = Random.Range(0, 3);
            Instantiate(item[a], itemPos[b].position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
}
