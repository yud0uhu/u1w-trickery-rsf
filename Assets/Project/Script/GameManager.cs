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
    public LoadScene load;

    public List<int> ransu;

    [SerializeField] float wordSpeed;
    int wordListIndex = 0;

    [SerializeField]
    SpriteRenderer auto;
    public Sprite auto_0;
    public Sprite auto_1;

    public TimeManager timer;

    public GameObject rsf;
    void Start()
    {
        InitGame();
    }

    IEnumerator LogServer()
    {
        while (properties.inGame==true) {
            properties.attensionLog.Add(properties.attension);
            //Debug.Log(properties.attensionLog);
            yield return new WaitForSeconds(1.0f);
        }
        yield return null;
    }

    IEnumerator firstPlay()
    {
        if (properties.firstPlay == true)
        {
            properties.uiMode.Value = UIMode.Tutolial;
            Debug.Log("びっくりするほどユートピア");
            yield return new WaitForSeconds(2.0f);
            properties.firstPlay = false;
            properties.uiMode.Value = UIMode.Main;
        }
    }


    void InitGame()
    {
        properties.firstPlay = true;
        properties.inGame = true;
        rsf.SetActive(false);
        properties.attensionLog.Clear();
        StartCoroutine("firstPlay");
        StartCoroutine("LogServer");

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
        if (timer.effect <= 1)
        {
            Debug.Log(ransu[0]);
            properties.uiMode.Value = UIMode.Action;

            // Effectは正負の値を動く
            properties.attension += actionDB.levels[ransu[num]].Effect;

            for (int element = 0; element < 2; element++)
            {
                auto.sprite = auto_0;
                wordListIndex = ransu[num];
                int wordCount = 0;
                action.text = "";
                while (actionDB.levels[wordListIndex].line[element].Length > wordCount)
                {
                    action.text += actionDB.levels[wordListIndex].line[element][wordCount];
                    wordCount++;
                    yield return new WaitForSeconds(wordSpeed);
                }
                auto.sprite = auto_1;
                yield return new WaitForSeconds(2.5f);
            }
            InitGame();
        } else
        {
            Debug.Log("警戒度");
            Debug.Log(properties.attension);
            load.LoadResult();
        }
    }
}
