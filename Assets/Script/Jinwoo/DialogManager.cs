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
            talk.SetMsg("옛날 어느 산속에 500년간 의적을 양성하는 \n도원이 있었다.");
        if(clicknum == 1)
            talk.SetMsg("거기에는 세상을 지배할만한 힘을 가진 도법서가 \n보관되어 있었는데...");
        if (clicknum == 2)
            talk.SetMsg("어느 날 정제를 알 수 없는 검은 세력이 세상을 \n자신들의 것으로 만들기 위해 도법서를 훔쳐간다");
        if (clicknum == 3)
        {
            talk.SetMsg("그 사실을 안 주인공 쿠로는 검은 세력이 \n세상을 지배하는것을 막고자 직접 도법서를 \n되찾으러 가는데...");
        }
        if (clicknum == 4)
        {
            SceneManager.LoadScene("Stage1");
        }
    }
   
}
