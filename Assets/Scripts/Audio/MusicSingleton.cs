using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour
{
    public static MusicSingleton Instance;
    private FMOD.Studio.EventInstance _music;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

       _music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/UIMusic");
        _music.start();

    }
}
