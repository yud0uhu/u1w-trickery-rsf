using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class Porker : MonoBehaviour
{

    [SerializeField] GameObject raiseCommand;
    [SerializeField] GameObject callCommand;
    [SerializeField] GameObject actionCommand;
    [SerializeField] GameProperties gameProperties;

    // Start is called before the first frame update
    public void Start()
    {
    }

// Update is called once per frame
    public void Bet()
    {
        this.gameObject.SetActive(false);
        actionCommand.SetActive(false);
        raiseCommand.SetActive(true);
        callCommand.SetActive(true);
    }

    public void Call()
    {
        gameProperties.yourBet = 50;
        gameProperties.opponentBet = 20;
        gameProperties.yourBet = gameProperties.opponentBet;
        gameProperties.yourTip -= gameProperties.yourBet;

        Debug.Log("Called");
        Debug.Log(gameProperties.yourTip);
    }

    public void Raise()
    {
        gameProperties.yourBet = gameProperties.opponentBet * 0.01;
        gameProperties.yourTip -= gameProperties.yourBet;
        Debug.Log(gameProperties.yourTip);
    }
}
