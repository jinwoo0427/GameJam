using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    public void OnClickYes()
    {
        SceneManager.LoadScene("jinwooScen");
    }
    public void OnClickNo()
    {
        SceneManager.LoadScene("StartScene");
    }
}
