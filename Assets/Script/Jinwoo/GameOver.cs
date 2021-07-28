using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public void OnClickYes()
    {
        SceneManager.LoadScene("Story");
    }
    public void OnClickNo()
    {
        SceneManager.LoadScene("StartScene");
    }
}
