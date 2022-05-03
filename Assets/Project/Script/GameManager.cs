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
    [SerializeField] Text action;

    void Start()
    {
        InitGame();
    }

    void InitGame()
    {
        properties.uiMode.Value = UIMode.Main;
        List<int> numbers = new List<int>();
        int index = 0;
        for (int i = 0; i <= 2; i++)
        {
            numbers.Add(i);
        }
        while (numbers.Count > 0)
        {
            index = Random.Range(0, numbers.Count);
            first.text = actionDB.levels[numbers[index]].actionName;
            action.text = actionDB.levels[numbers[index]].line[0];
            //Debug.Log(index);
            numbers.RemoveAt(index);
            index = Random.Range(0, numbers.Count);
            seccond.text = actionDB.levels[numbers[index]].actionName;
            action.text = actionDB.levels[numbers[index]].line[0];
            //Debug.Log(index);
            numbers.RemoveAt(index);
            index = Random.Range(0, numbers.Count);
            third.text = actionDB.levels[numbers[index]].actionName;
            action.text = actionDB.levels[numbers[index]].line[0];
            //Debug.Log(index);
            numbers.RemoveAt(index);
        }
    }

    public void onClickAction()
    {
        properties.uiMode.Value = UIMode.Action;
    }

    public void GameOver()
    {
        
    }
}
