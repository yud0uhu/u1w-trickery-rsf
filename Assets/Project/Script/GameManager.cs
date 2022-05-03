using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameProperties properties;
    [SerializeField] ActionDB actionDB;
    [SerializeField] Text first;
    [SerializeField] Text seccond;
    [SerializeField] Text third;

    void Start()
    {
        InitGame();
    }

    void InitGame()
    {
        List<int> numbers = new List<int>();
        for (int i=0; i<=3; i++)
        {
            numbers.Add(i);
        }
        while (numbers.Count > 0)
        {
            int index = Random.Range(0, 3);
            first.text = actionDB.levels[numbers[index]].actionName;
            seccond.text = actionDB.levels[numbers[index+1]].actionName;
            third.text = actionDB.levels[numbers[index + 2]].actionName;
        }
    }

    public void GameOver()
    {
        
    }
}
