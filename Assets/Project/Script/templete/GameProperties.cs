using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameProperties", menuName = "GameProperties")]
public class GameProperties : ScriptableObject
{
    public int score;
    public double yourBet;
    public double opponentBet;
    public double yourTip;
    public double opponentTip;
    public ReactiveProperty<UIMode> uiMode;
}
