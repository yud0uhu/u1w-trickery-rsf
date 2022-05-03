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
        int index = 0;
        for (int i=0; i<=3; i++)
        {
            numbers.Add(i);
        }
        while (numbers.Count > 0)
        {
            index = Random.Range(0, numbers.Count);
            first.text = actionDB.levels[numbers[index]].actionName;
            numbers.RemoveAt(index);
            seccond.text = actionDB.levels[numbers[index]].actionName;
            numbers.RemoveAt(index);
            third.text = actionDB.levels[numbers[index]].actionName;
            numbers.RemoveAt(index);
        }
    }

    public void GameOver()
    {
        
    }
}
