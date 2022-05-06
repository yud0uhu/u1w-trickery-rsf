using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void LoadResult()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

}
