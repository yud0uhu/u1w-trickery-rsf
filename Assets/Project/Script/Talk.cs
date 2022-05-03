using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    [SerializeField] GameObject actionCommand;
    [SerializeField] GameObject choiceCommand;

    public void Choises()
    {
        choiceCommand.SetActive(true);
    }
}
