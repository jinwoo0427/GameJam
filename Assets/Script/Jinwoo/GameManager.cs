using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject pausePanel;
    private bool escbutton = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseAction();
        }
    }
    public void PauseAction()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void ResumeAction()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void RestartAction(int Scenenum)
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        SceneManager.LoadScene(Scenenum);  
    }
    public void MainMenuAction()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        SceneManager.LoadScene("StartScene");
    }

    public void NEXT()
    {
        SceneManager.LoadScene("Stage21");
    }
}
