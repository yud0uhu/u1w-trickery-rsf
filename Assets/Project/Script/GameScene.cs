using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameScene : MonoBehaviour
{
    [SerializeField] GameProperties properties;
    [SerializeField] UIMode uiMode;
    public void onclick()
    {
        //SceneManager.LoadScene("SimpleScene", LoadSceneMode.Single);
        properties.uiMode.Value = uiMode;
    }
}
