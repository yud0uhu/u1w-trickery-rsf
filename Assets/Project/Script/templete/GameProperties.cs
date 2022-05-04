using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameProperties", menuName = "GameProperties")]
public class GameProperties : ScriptableObject
{
    public bool inGame;
    public int score;
    public int attension;
    public List<int> attensionLog;
    public ReactiveProperty<UIMode> uiMode;
}
