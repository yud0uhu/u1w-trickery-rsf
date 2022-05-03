using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Porker : MonoBehaviour
{

    [SerializeField] GameObject raiseCommand;
    [SerializeField] GameObject callCommand;
    [SerializeField] GameObject actionCommand;
    [SerializeField] GameObject showCardCommand;
    [SerializeField] GameProperties gameProperties;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Bet()
    {
        this.gameObject.SetActive(true);
        actionCommand.SetActive(true);
        raiseCommand.SetActive(true);
        callCommand.SetActive(true);
        showCardCommand.SetActive(false);
    }

    public void Call()
    {
        gameProperties.yourBet = gameProperties.opponentBet;
        gameProperties.yourTip -= gameProperties.yourBet;

        Debug.Log("Called");
        Debug.Log(gameProperties.yourTip);
        // スコアボード画面に遷移する10f秒間、イカサマコマンドが選択可能
        DOVirtual.DelayedCall(10f, () => showCard());
    }

    public void Raise()
    {
        gameProperties.yourBet = gameProperties.opponentBet * 0.01;
        gameProperties.yourTip -= gameProperties.yourBet;
        Debug.Log(gameProperties.yourTip);
        // スコアボード画面に遷移する10f秒間、イカサマコマンドが選択可能
        DOVirtual.DelayedCall(10f, () => showCard());
    }

    public void showCard()
    {
        raiseCommand.SetActive(false);
        callCommand.SetActive(false);
        showCardCommand.SetActive(true);
        Debug.Log(gameProperties.yourTip);
    }

    // TODO:スコアクラスに分離したい
    public void showScore()
    {
        Debug.Log("Show Score\n");
    }
}
