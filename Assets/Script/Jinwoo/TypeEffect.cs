using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int charPerseconds;
    private string targetMsg;
    private Text mesText;
    private int index;
    float interval;
    private void Awake()
    {
        mesText = GetComponent<Text>();
    }

    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();

    }

    private void EffectStart()
    {

        mesText.text = "";
        index = 0;

        interval = 0.5f / charPerseconds;
        Invoke("Effecting", 1 / charPerseconds);
    }

    private void Effecting()
    {
        if(mesText.text == targetMsg)
        {
            return;
        }
        mesText.text += targetMsg[index];
        index++;

        Invoke("Effecting", interval);
    }
  


}
