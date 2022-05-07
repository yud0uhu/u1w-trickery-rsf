using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneAudioEffect : MonoBehaviour
{
    [SerializeField] GameProperties properties;
    bool pitchup=false;
    void Update()
    {
        if (pitchup == false&&properties.restTime>45)
        {
            AudioManager.PitchChange(1.1f);
            pitchup = true;
        }
        if (properties.inGame == true)
        {
            float vol = (float)properties.attension / 200;
            if (vol < 0.1f) vol = 0.1f;
            AudioManager.VolumeChange(vol);
        }
    }
}
