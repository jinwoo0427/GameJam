using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SulMyung : MonoBehaviour
{
    [SerializeField]
    private GameObject[] sul;
    public void Sul1()
    {
        sul[0].SetActive(true);
        sul[1].SetActive(false);
    }
    public void Sul2()
    {
        sul[0].SetActive(false);
        sul[1].SetActive(true);
        sul[2].SetActive(false);
    }
    public void Sul3()
    {
        sul[1].SetActive(false);
        sul[2].SetActive(true);
        sul[3].SetActive(false);
    }
    public void Sul4()
    {
        sul[2].SetActive(false);
        sul[3].SetActive(true);
        sul[4].SetActive(false);
    }
    public void Sul5()
    {
        sul[3].SetActive(false);
        sul[4].SetActive(true);
        sul[5].SetActive(false);
    }
    public void Sul6()
    {
        sul[4].SetActive(false);
        sul[5].SetActive(true);
        sul[6].SetActive(false);
    }
    public void Sul7()
    {
        sul[5].SetActive(false);
        sul[6].SetActive(true);
    }
    public void Exit()
    {
        sul[0].SetActive(false);
        sul[1].SetActive(false);
        sul[2].SetActive(false);
        sul[3].SetActive(false);
        sul[4].SetActive(false);
        sul[5].SetActive(false);
        sul[6].SetActive(false);
    }

}
