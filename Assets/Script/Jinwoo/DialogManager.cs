using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public TypeEffect talk;

    private int clicknum = 0;

    [SerializeField]
    private AudioSource sound;
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
            talk.SetMsg("���� ��� ��ӿ� 500�Ⱓ ������ �缺�ϴ� \n������ �־���.");
            sound.Play();
        }
        if(clicknum == 1)
        {
            talk.SetMsg("�ű⿡�� ������ �����Ҹ��� ���� ���� �������� \n�����Ǿ� �־��µ�...");
            sound.Play();
        }
        if (clicknum == 2)
        {
            talk.SetMsg("��� �� ��ü�� �� �� ���� ���� ������ ������ \n�ڽŵ��� ������ ����� ���� �������� ���İ���");
            sound.Play();
        }
        if (clicknum == 3)
        {
            talk.SetMsg("�� ����� �� ���ΰ� ��δ� ���� ������ \n������ �����ϴ°��� ������ ���� �������� \n��ã���� ���µ�...");
            sound.Play();
        }
        if (clicknum == 4)
        {
            SceneManager.LoadScene("Stage1");
        }
    }
   
}
