using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class DrawChart : MonoBehaviour
{
    [SerializeField] LineChart lineChart;
    [SerializeField] GameProperties properties;
    [SerializeField] AudioClip audioClip;
    //private LineChart linechart;
    // Start is called before the first frame update
    void Start()
    {
        lineChart.RemoveData();
        lineChart.AddSerie(SerieType.Line);
        //lineChart.xAxis0,;
        int listlength = properties.attensionLog.Count;
        for (int i = 0; i < 60; i++)
        {
            if (listlength > i)
            {
                Debug.Log("check");
                lineChart.AddData(0,properties.attensionLog[i]);

            }
            //lineChart.AddXAxisData(i.ToString());
            //lineChart.AddData(0, Random.Range(0, 65));
        }
        AudioManager.SE_Play(audioClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
