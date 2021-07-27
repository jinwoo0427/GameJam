using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndingEffect : MonoBehaviour
{
    GameObject SplashObj;

    Image image;

    private bool checkbool = false;


    void Awake()
    {
        SplashObj = this.gameObject;
        image = SplashObj.GetComponent<Image>();
    }

    void Update()
    {
        StartCoroutine("MainSplash");
        if (checkbool)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator MainSplash()
    {
        Color color = image.color;
        for (int i = 0; i <= 200; i++)
        {
            color.a += Time.deltaTime * 0.003f;
            image.color = color;

            if (image.color.a >= 200)
            {
                checkbool = true;
            }
        }
        yield return null;
    }
}
