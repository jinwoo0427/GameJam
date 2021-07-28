using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] audio;
    public void Click1()
    {
        audio[0].Play();
    }
    public void Click2()
    {
        audio[1].Play();
    }
}
