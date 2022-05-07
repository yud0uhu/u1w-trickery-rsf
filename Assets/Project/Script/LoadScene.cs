using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] AudioClip buttonSE;
    [SerializeField] AudioClip resultSE;
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        AudioManager.SE_Play(buttonSE);
    }

    public void LoadResult()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        AudioManager.SE_Play(resultSE);
    }

}
