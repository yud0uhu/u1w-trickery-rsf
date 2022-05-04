using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameProperties properties;
    [SerializeField] ActionDB actionDB;
    [SerializeField] Text first;
    [SerializeField] Text second;
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
        List<int> ransu = new List<int>();
        for (int i = 0; i <= 2; i++)
        {
            numbers.Add(i);
        }

        while (numbers.Count > 0)
        {
            int index = Random.Range(0, numbers.Count);

            ransu.Add(numbers[index]);
            Debug.Log(ransu);
            numbers.RemoveAt(index);
        }

        first.text = actionDB.levels[ransu[0]].actionName;
        second.text = actionDB.levels[ransu[1]].actionName;
        third.text = actionDB.levels[ransu[2]].actionName;
        

    }

    public void onClickAction(int num)
    {
        StartCoroutine(Action(num));
    }

    IEnumerator Action(int num)
    {
        properties.uiMode.Value = UIMode.Action;
        int i = 4;
        while (i >= 0)
        {
            if (num == 0)
            {
                if (first.text == actionDB.levels[i].actionName)
                {
                    Debug.Log(i);
                    action.text = actionDB.levels[i].line[0];
                    yield return new WaitForSeconds(2.5f);
                    action.text = actionDB.levels[i].line[1];
                    yield return new WaitForSeconds(2.5f);
                    InitGame();
                }
            }
            else if (num == 1)
            {

                if (second.text == actionDB.levels[i].actionName)
                {
                    Debug.Log(i);
                    action.text = actionDB.levels[i].line[0];
                    yield return new WaitForSeconds(2.5f);
                    action.text = actionDB.levels[i].line[1];
                    yield return new WaitForSeconds(2.5f);
                    InitGame();
                }
            }
            else if (num == 2)
            {

                if (third.text == actionDB.levels[i].actionName)
                {
                    Debug.Log(i);
                    action.text = actionDB.levels[i].line[0];
                    yield return new WaitForSeconds(2.5f);
                    action.text = actionDB.levels[i].line[1];
                    yield return new WaitForSeconds(2.5f);
                    InitGame();
                }
            }
            i--;
        }
    }

    public void GameOver()
    {
        
    }
}
