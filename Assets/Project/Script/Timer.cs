using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float second;
    private int minute;
    private int hour;
    [SerializeField] GameObject timer_fill;

    void Start()
    {
        
    }

    void Update()
    {
        //second += Time.deltaTIme;
    }
}
