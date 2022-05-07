using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] AudioClip bottunSE;
    public void LoadGame()
    {
        AudioManager.SE_Play(bottunSE);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void LoadResult()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

}
