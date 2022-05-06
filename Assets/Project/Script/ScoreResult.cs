using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreResult : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] GameProperties properties;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score\n"+properties.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
