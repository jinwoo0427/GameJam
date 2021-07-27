using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OnStartSC : MonoBehaviour
{
   
    [SerializeField]
    private GameManager gameManager;
    private Animator animator;

    void Start()
    {
        StartCoroutine(Scene());
    }


    void Update()
    {

    }
    private IEnumerator Scene()
    {
       
        yield return new WaitForSeconds(60f);
        gameManager.NEXT();
    }

}