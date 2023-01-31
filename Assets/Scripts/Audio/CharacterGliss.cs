using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGliss : MonoBehaviour
{
    [SerializeField] private string eventName;


    public void PlayCharacterGliss()
    {
        FMODUnity.RuntimeManager.PlayOneShot($"event:/CharacterSounds/{eventName}");
    }

    

}
