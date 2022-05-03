using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameProperties", menuName = "GameProperties")]
public class GameProperties : ScriptableObject
{
    public int score;
    public double yourBet;
    public double opponentBet;
    public double yourTip;
    public double opponentTip;
}
