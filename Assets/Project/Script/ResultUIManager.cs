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
    // Start is called before the first frame update
    void Start()
    {
        audioManager= GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        //ƒ^ƒbƒv‚ÅŽŸ‚Ö‚Æ‚©ŽÀ‘•‚·‚é
        if (gameProperties.isSuccessTrick == true)
        {
            clear.text = "Clear!!";
        }
        else
        {
            clear.text = "GameOver";
        }
        
        for (int i = 0; i < winobj.Count; i++)
        {
            winobj[i].SetActive(gameProperties.isSuccessTrick);
        }
        //score.text = ((gameProperties.restTime + 1) * 1000).ToString();
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
        audioManager.returnBGM();
        SceneManager.LoadScene("GameScene");
    }
    public void OnclickEnd()
    {
        audioManager.returnBGM();
        SceneManager.LoadScene("Title");
    }
}
