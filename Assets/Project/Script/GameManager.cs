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
    public List<int> ransu;

    void Start()
    {
        InitGame();
    }


    void InitGame()
    {
        properties.uiMode.Value = UIMode.Main;
        List<int> numbers = new List<int>();
        ransu = new List<int>();
        for (int i = 0; i <= 4; i++)
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
        Debug.Log(ransu[0]);
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
        Debug.Log(ransu[0]);
        properties.uiMode.Value = UIMode.Action;
        action.text = actionDB.levels[ransu[num]].line[0];
        yield return new WaitForSeconds(2.5f);
        action.text = actionDB.levels[ransu[num]].line[1];
        yield return new WaitForSeconds(2.5f);
        InitGame();
    }

    public void GameOver()
    {
        
    }
}
