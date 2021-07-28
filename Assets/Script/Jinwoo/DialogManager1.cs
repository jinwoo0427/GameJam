using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager1 : MonoBehaviour
{
    public TypeEffect talk;

    private int clicknum = 0;
    [SerializeField]
    private AudioSource audio;
    void Start()
    {
        clicknum = 0;
        Invoke("Talking", 1.5f);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            clicknum += 1;
            Talking();
        }
        
    }
    public void Talking()
    {
        if (clicknum == 0)
        {
            audio.Play();
            talk.SetMsg("���������� ��θӸ��� ��ġ���");
        }
        if(clicknum == 1)
        {
            audio.Play();
            talk.SetMsg("�ᱹ �������� ��ã�� ��δ� \n������ ��ȭ�� ���״�.");
        }
        if (clicknum == 2)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
   
}
