using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLandingSound : MonoBehaviour
{
    [SerializeField] private Player playerScript;

    public void PlayLandingSound()
    {
        if (playerScript.isGrounded)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/CharacterSounds/Character_Landing");
        }
    }
}
