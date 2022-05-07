using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameProperties", menuName = "GameProperties")]
public class GameProperties : ScriptableObject
{
    public bool inGame;
    public bool firstPlay = true;
    public bool firstWin;
    public bool isSuccessTrick;
    public int score;
    public double restTime;
    public bool timerSwitch;
    public bool timeOver=false;
    public int attension;
    public List<int> attensionLog;
    public ReactiveProperty<UIMode> uiMode;
    public int EnemyLevel = 0;
    public List<string> enemyname;
}
