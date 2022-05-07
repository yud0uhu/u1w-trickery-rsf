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
    GameObject Audio;
    AudioManager audioManager;

    private void Start()
    {
        Audio = GameObject.FindGameObjectWithTag("Audio");
        audioManager = Audio.GetComponent<AudioManager>();
    }
    public void trick()
    {
        properties.uiMode.Value = UIMode.Main;
        if (properties.attension < 30)
        {
            properties.isSuccessTrick = true;
            properties.uiMode.Value = UIMode.Trick;
            audioManager.TrickBGM();
            Debug.Log("成功！！！！！！！");
            StartCoroutine("SucsessTrick");

        } else
        {
            properties.isSuccessTrick = false;
            StartCoroutine("FailedTrick");
        }
    }

    IEnumerator SucsessTrick()
    {
        yield return new WaitForSeconds(2.5f);
        load.LoadResult();
    }

    IEnumerator FailedTrick()
    {
        if (properties.isSuccessTrick == false)
        {
            attention.sprite = attention_img;
            int wordCount = 0;
            int wordListIndex = 0;
            action.text = "";
            properties.uiMode.Value = UIMode.Action;
            while (messageList[wordListIndex].Length > wordCount)
            {
                auto.sprite = auto_0;
                action.text += messageList[wordListIndex][wordCount];
                wordCount++;
                wordSpeed = wordCount / 100;
                yield return new WaitForSeconds(wordSpeed);
            }
            auto.sprite = auto_1;
            yield return new WaitForSeconds(2.5f);
        }
        load.LoadResult();
    }
}
