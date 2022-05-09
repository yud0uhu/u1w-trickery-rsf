using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
    [SerializeField] AudioClip trickSuccessSE;
    [SerializeField] AudioClip trickFailedSE;
    int clearLine;
    [SerializeField] GameObject actionWindow;
    [SerializeField] GameObject flash;

    private void Start()
    {
        Audio = GameObject.FindGameObjectWithTag("Audio");
        audioManager = Audio.GetComponent<AudioManager>();
    }
    public void trick()
    {
        if (properties.firstWin == false)
        {
            clearLine = 30;
        }
        if (clearLine >= 0)
        {
            clearLine -= properties.EnemyLevel * 5;
        }
        else
        {
            clearLine = 0;
        }
        properties.uiMode.Value = UIMode.Main;
        Debug.Log("クリアライン" + clearLine);
        Debug.Log("警戒度" + properties.attension);
        if (properties.attension < clearLine && properties.timeOver == false)
        {
            properties.isSuccessTrick = true;
            properties.uiMode.Value = UIMode.Trick;
            audioManager.TrickBGM();
            Debug.Log("成功！！！！！！！");
            SucsessTrick();

        }
        else
        {
            properties.isSuccessTrick = false;
            FailedTrick();
        }
    }

    void SucsessTrick()
    {
        actionWindow.GetComponent<RectTransform>().DOShakePosition(1f, 5f, 30, 1, false, true).SetEase(Ease.OutBack, 5f).OnComplete(() =>
        {
            StartCoroutine("ShowText");
            AudioManager.SE_Play(trickSuccessSE);
            Invoke("LoadResult", 1.0f);
        });
    }

    void FailedTrick()
    {
        actionWindow.SetActive(true);
        actionWindow.GetComponent<RectTransform>().DOMoveY(2f,0.3f).SetEase(Ease.OutBack).OnComplete(async () =>
        {
            StartCoroutine("ShowText");
            AudioManager.SE_Play(trickFailedSE);
            Invoke("LoadResult",1.0f);
        });
    }

    void LoadResult()
    {
        load.LoadResult();
    }

    IEnumerator ShowText()
    {
        if (properties.isSuccessTrick == false)
        {
            attention.sprite = attention_img;
            int wordCount = 0;
            int wordListIndex=0;
            action.text = "";
            properties.uiMode.Value = UIMode.Action;
            if (properties.timeOver == true)
            {
                wordListIndex = 1;
            }
            while (messageList[wordListIndex].Length > wordCount)
            {
                auto.sprite = auto_0;
                action.text += messageList[wordListIndex][wordCount];
                wordCount++;
                //wordSpeed = wordCount / 100;
                //yield return new WaitForSeconds(wordSpeed);
            }
            auto.sprite = auto_1;
            yield return new WaitForSeconds(2.5f);
        } else
        {
            // 成功時のカットイン
            var image = flash.GetComponent<Image>();
            DOTween.To(() => image.color, x => image.color = x, new Color32(0, 0, 0, 255), 1f).SetEase(Ease.Flash);
        }
    }
}
