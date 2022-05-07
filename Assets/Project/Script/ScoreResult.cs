using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreResult : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] GameProperties properties;
    //[SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    void Start()
    {
        var tmp = (int)((60 - (properties.restTime) + 1) * 1000);
        if (tmp <= 0)
        {
            tmp = 0;
        }
        if (properties.isSuccessTrick == true)
        {
            //AudioManager.SE_Play(audioClip);
            audioSource.Play();
            tmp = tmp * 20;
        }
        text.text = "Score\n"+ tmp.ToString();

    }
}
