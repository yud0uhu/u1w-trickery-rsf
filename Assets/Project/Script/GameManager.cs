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
    private LoadScene load;
    public Trick trick;
    public Tutorial tutorial;

    public List<int> ransu;

    [SerializeField] float wordSpeed;
    int wordListIndex = 0;

    [SerializeField]
    SpriteRenderer auto;
    public Sprite auto_0;
    public Sprite auto_1;

    public TimeManager timer;
    [SerializeField] AudioClip buttonSE;

    void Start()
    {
        InitGame();
    }

    IEnumerator LogServer()
    {
        if (properties.timerSwitch == true)
        {
            while (properties.inGame == true)
            {
                properties.attensionLog.Add(properties.attension);
                Debug.Log(properties.attension);
                yield return new WaitForSeconds(1.0f);
            }
        }
        yield return null;
    }

    private void firstPlay()
    {
        properties.uiMode.Value = UIMode.Tutorial;
        tutorial.LoadTutorial();
    }

    IEnumerator TimerWatch()
    {
        while (true)
        {
            //Debug.Log("timerrrrrrr");
            //Debug.Log(timer.effect);
            //timer.effect = timer.TimeOver();
            //timer.effectは時間経過で加算されていく
            if (timer.effect >= 1)
            {
                // ゲームオーバー演出
                properties.isSuccessTrick = false;
                properties.timeOver = true;
                trick.trick();
            }
            yield return null;
        }
    }


    void InitGame()
    {
        properties.isSuccessTrick = false;
        properties.attension = 100;
        properties.inGame = true;
        properties.timerSwitch = true;
        properties.attensionLog.Clear();
        properties.uiMode.Value = UIMode.Main;
        StartCoroutine("LogServer");
        LoadAction();
        StartCoroutine("TimerWatch");
        if (properties.firstPlay == true)
        {
            firstPlay();
        }
    }

    void LoadAction()
    {
        List<int> numbers = new List<int>();
        ransu = new List<int>();
        for (int i = 0; i < actionDB.levels.Count; i++)
        {
            numbers.Add(i);
        }

        while (numbers.Count > 0)
        {
            int index = Random.Range(0, numbers.Count);

            ransu.Add(numbers[index]);
            //Debug.Log(ransu);
            numbers.RemoveAt(index);
        }
        //Debug.Log(ransu[0]);
        first.text = actionDB.levels[ransu[0]].actionName;
        second.text = actionDB.levels[ransu[1]].actionName;
        third.text = actionDB.levels[ransu[2]].actionName;

        properties.uiMode.Value = UIMode.Main;
    }


    public void onClickAction(int num)
    {
        AudioManager.SE_Play(buttonSE);
        StartCoroutine(Action(num));
    }


    IEnumerator Action(int num)
    {

        //Debug.Log(ransu[0]);
        properties.uiMode.Value = UIMode.Action;

        // Effectは30～-20
        properties.attension -= actionDB.levels[ransu[num]].Effect;

        for (int element = 0; element < actionDB.levels[ransu[num]].line.Count; element++)
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
        LoadAction();
        //Debug.Log(timer.effect);
    }


}
