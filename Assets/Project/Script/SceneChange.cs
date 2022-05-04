using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCange : MonoBehaviour
{
    void onclick()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
