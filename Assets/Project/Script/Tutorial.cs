using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameProperties properties;
    [SerializeField] Text action;
    [SerializeField] List<string> messageList = new List<string>();
    [SerializeField]
    SpriteRenderer auto;
    public Sprite auto_0;
    public Sprite auto_1;
    [SerializeField] float wordSpeed;
    int wordListIndex = 0;

    public void LoadTutorial()
    {
        properties.timerSwitch = false;
        StartCoroutine("TutorialAction");
    }

    IEnumerator TutorialAction()
    {
        while (wordListIndex < 3)
        {
            int wordCount = 0;
            action.text = "";
            while (messageList[wordListIndex].Length > wordCount)
            {
                auto.sprite = auto_0;
                action.text += messageList[wordListIndex][wordCount];
                wordCount++;
                yield return new WaitForSeconds(wordSpeed);
            }
            auto.sprite = auto_1;
            yield return new WaitForSeconds(3.0f);
            wordListIndex++;
        }
        properties.timerSwitch = true;
        properties.firstPlay = false;
        properties.uiMode.Value = UIMode.Main;
    }
}
