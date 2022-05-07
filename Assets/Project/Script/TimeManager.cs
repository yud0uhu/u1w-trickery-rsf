using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    [SerializeField] GameProperties properties;
    // フレームレートを1/60秒に固定
    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private float countup = 0.0f;
    [SerializeField] Image timer_fill;
    public float effect;

    void Start()
    {
        effect = 0;
    }

    public void Update()
    {
        if (effect >= 0)
        {
            countup += Time.deltaTime;
            effect = countup / 60;
            timer_fill.fillAmount = effect;
            properties.restTime = countup;
        }
    }

}
