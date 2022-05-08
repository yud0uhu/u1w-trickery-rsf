using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ResultUIManager : MonoBehaviour
{
    [SerializeField] GameObject nextwindow;
    [SerializeField] Text score;
    [SerializeField] Text clear;
    [SerializeField] GameProperties gameProperties;
    [SerializeField] List<GameObject> winobj = new List<GameObject>();
    AudioManager audioManager;
    [SerializeField] GameObject nextbutton;
    [SerializeField] GameObject sharebutton;
    [SerializeField] AudioClip button;
    [SerializeField] GameObject card;
    [SerializeField] GameObject rsf;
    // Start is called before the first frame update
    void Start()
    {
        audioManager= GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        //タップで次へとか実装する
        if (gameProperties.isSuccessTrick == true)
        {
            //clear.text = "Clear!!";
            clear.text = "";
            clear.DOText("Clear!!", 1f);
        }
        else
        {
            clear.text = "";
            clear.DOText("GameOver", 1f);
            //clear.text = "GameOver";
        }
        
        for (int i = 0; i < winobj.Count; i++)
        {
            winobj[i].SetActive(gameProperties.isSuccessTrick);
        }
        //score.text = ((gameProperties.restTime + 1) * 1000).ToString();

        DOTween.To(() => card.transform.position, x => card.transform.position = x, new Vector3(0,0,0), 1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onclick()
    {
        nextwindow.SetActive(true);
        if (gameProperties.isSuccessTrick == false)
        {
            nextbutton.SetActive(false);
        }
    }
    public void OnClickNext()
    {
        AudioManager.SE_Play(button);
        audioManager.returnBGM();
        if (gameProperties.EnemyLevel <= 3) gameProperties.EnemyLevel++;
        SceneManager.LoadScene("GameScene");
    }
    public void OnclickEnd()
    {
        gameProperties.score = 0;
        gameProperties.EnemyLevel = 0;
        AudioManager.SE_Play(button);
        audioManager.returnBGM();
        SceneManager.LoadScene("Title");
    }
    public void OnclickShare()
    {
        gameProperties.score = 0;
        gameProperties.EnemyLevel = 0;
        AudioManager.SE_Play(button);
        audioManager.returnBGM();
        naichilab.UnityRoomTweet.Tweet("trick_rsf", "あなたのイカサマは"+gameProperties.score.ToString()+"点です", "ikasama_royal_straight_flush");
    }
}
