using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionDB", menuName = "ActionDB")]
public class ActionDB : ScriptableObject
{
    public List<Action> levels = new List<Action>();
}
