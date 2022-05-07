using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameProperties gameProperties;
    [SerializeField] UIMode myUIelementsMode;
    // Start is called before the first frame update
    private void Awake()
    {
        IDisposable subscription = gameProperties.uiMode.Subscribe(x => {
            this.gameObject.SetActive(x == myUIelementsMode);
        }).AddTo(this.gameObject);
    } 
}
