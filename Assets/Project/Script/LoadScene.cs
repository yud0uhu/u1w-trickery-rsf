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
        AudioManager.SE_Play(buttonSE);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        AudioManager.SE_Play(buttonSE);
    }

    public void LoadResult()
    {
        AudioManager.PitchChange(1.0f);
        AudioManager.VolumeChange(0.5f);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        AudioManager.SE_Play(resultSE);
    }

}
