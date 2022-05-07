using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trick : MonoBehaviour
{
    [SerializeField] GameProperties properties;
    public LoadScene load;
    [SerializeField]
    SpriteRenderer auto;
    public Sprite auto_0;
    public Sprite auto_1;
    [SerializeField]
    SpriteRenderer attention;
    public Sprite attention_img;
    [SerializeField] List<string> messageList = new List<string>();
    [SerializeField] Text action;
    [SerializeField] float wordSpeed;
    int wordListIndex = 0;
    public void trick()
    {
        properties.uiMode.Value = UIMode.Main;
        if (properties.attension > 100)
        {
            properties.isSuccessTrick = true;
            properties.uiMode.Value = UIMode.Trick;
            Debug.Log("成功！！！！！！！");
            load.LoadResult();

        } else
        {
            properties.isSuccessTrick = false;
            StartCoroutine("FailedTrick");
        }
    }

    IEnumerator FailedTrick()
    {
        if (properties.isSuccessTrick == false)
        {
            attention.sprite = attention_img;
            int wordCount = 0;
            action.text = "";
            properties.uiMode.Value = UIMode.Action;
            while (messageList[wordListIndex].Length > wordCount)
            {
                auto.sprite = auto_0;
                action.text += messageList[wordListIndex][wordCount];
                wordCount++;
                yield return new WaitForSeconds(wordSpeed);
            }
            auto.sprite = auto_1;
            yield return new WaitForSeconds(2.5f);
            load.LoadResult();
        }
    }
}
