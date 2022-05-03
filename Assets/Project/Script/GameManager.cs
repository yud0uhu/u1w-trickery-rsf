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
    [SerializeField] Text seccond;
    [SerializeField] Text third;
    [SerializeField] Text action;

    void Start()
    {
        properties.uiMode.Value = UIMode.Main;
        InitGame();
    }


    void InitGame()
    {
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
        seccond.text = actionDB.levels[ransu[1]].actionName;
        third.text = actionDB.levels[ransu[2]].actionName;
        

    }

    public void onClickAction()
    {
        StartCoroutine("Action");
    }

    IEnumerator Action()
    {
        properties.uiMode.Value = UIMode.Action;
        int i = 4;
        while (i > 0)
        {
            if (first.text == actionDB.levels[i].actionName || seccond.text == actionDB.levels[i].actionName || third.text == actionDB.levels[i].actionName)
            {
                action.text = actionDB.levels[i].line[0];
                yield return new WaitForSeconds(3.5f);
                action.text = actionDB.levels[i].line[1];
            }
            i--;
        }
    }

    public void GameOver()
    {
        
    }
}
