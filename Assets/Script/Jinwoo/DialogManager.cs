using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public TypeEffect talk;

    private int clicknum = 0;


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
            talk.SetMsg("���� ��� ��ӿ� 500�Ⱓ ������ �缺�ϴ� \n������ �־���.");
        if(clicknum == 1)
            talk.SetMsg("�ű⿡�� ������ �����Ҹ��� ���� ���� �������� \n�����Ǿ� �־��µ�...");
        if (clicknum == 2)
            talk.SetMsg("��� �� ������ �� �� ���� ���� ������ ������ \n�ڽŵ��� ������ ����� ���� �������� ���İ���");
        if (clicknum == 3)
        {
            talk.SetMsg("�� ����� �� ���ΰ� ��δ� ���� ������ \n������ �����ϴ°��� ������ ���� �������� \n��ã���� ���µ�...");
        }
        if (clicknum == 4)
        {
            SceneManager.LoadScene("Stage1");
        }
    }
   
}
