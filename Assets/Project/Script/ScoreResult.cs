using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreResult : MonoBehaviour
{
    [SerializeField] Text Scoretext;
    [SerializeField] Text Scorenum;
    [SerializeField] GameProperties properties;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioClip audioClip2;
    [SerializeField] AudioSource audioSource;
    public int Score;
    void Start()
    {
        int tmp1=1000;
        int tmp2=Mathf.Abs((int)((60 - (properties.restTime) + 1)))*tmp1;
        int tmp3=(properties.EnemyLevel+1)*tmp2;
        int tmp4;
        if (properties.isSuccessTrick == true)
        {
        tmp4 = tmp3 * 20;
        }
        else { tmp4 = tmp3; }

        int tmp5 = tmp4 + properties.score;
        properties.score = tmp5;
        Score = tmp5;
        var tmp = (int)((60 - (properties.restTime) + 1) * 1000);
        if (properties.isSuccessTrick == true)
        {
            //AudioManager.SE_Play(audioClip);
            //audioSource.Play();
            tmp = tmp * 20;
        }
        //Scoretext.text = "Score\n"+ tmp.ToString();


        //var tweenFadeOut = DOTween.To(() => BGM_audio.volume, x => BGM_audio.volume = x, 0f, 0.2f);
        //var tweenFadeIn = DOTween.To(() => BGM_audio.volume, x => BGM_audio.volume = x, 0.5f, 0.2f).OnStart(() => changeBGM(clip));
        //seq = DOTween.Sequence().Append(tweenFadeOut).Append(tweenFadeIn);
        DOTween.Sequence()
            .Append(Scoretext.DOText("BaseScore", 0.5f).OnComplete(Score_Play))
            .Append(Scoretext.DOText("TimeBonus", 0.5f).SetDelay(0.5f).OnComplete(Score_Play))
            .Append(Scoretext.DOText("LevelBonus", 0.5f).SetDelay(0.5f).OnComplete(Score_Play))
            .Append(Scoretext.DOText("WinBonus", 0.5f).SetDelay(0.5f).OnComplete(Score_Play))
            .Append(Scoretext.DOText("TotalScore", 0.5f).SetDelay(0.5f).OnComplete(Total_Play))
            ;
        DOTween.Sequence()
            .Append(Scorenum.DOCounter(0, tmp1, 0.5f, false))
            .Append(Scorenum.DOCounter(tmp1, tmp2, 0.5f, false).SetDelay(0.5f))
            .Append(Scorenum.DOCounter(tmp2, tmp3, 0.5f, false).SetDelay(0.5f))
            .Append(Scorenum.DOCounter(tmp3, tmp4, 0.5f, false).SetDelay(0.5f))
            .Append(Scorenum.DOCounter(tmp4, tmp5, 0.5f, false).SetDelay(0.5f))
            ;
        
    }
    void Score_Play()
    {
        audioSource.clip = audioClip2;
        audioSource.Play();
    }
    void Total_Play()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
