using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneEffect : MonoBehaviour
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
        for (int i = 200; i >= 0; i--)                            
        {
            color.a -= Time.deltaTime * 0.003f;               
            image.color = color;                                

            if (image.color.a <= 0)                        
            {
                checkbool = true;                               
            }
        }
        yield return null;                                      
    }

}