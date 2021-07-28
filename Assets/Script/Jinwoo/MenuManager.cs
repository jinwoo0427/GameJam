using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public IEnumerator GameStart()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }
    public void GoGameScene()
    {
        StartCoroutine(GameStart());
    }
    public IEnumerator GameExit()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
    public void Quit()
    {
        StartCoroutine(GameExit());
    }
    public void Test()
    {
        StartCoroutine(TestPlay());
    }
    IEnumerator TestPlay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(10);
    }
}
