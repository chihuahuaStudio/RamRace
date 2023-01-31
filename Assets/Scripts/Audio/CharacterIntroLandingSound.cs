using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIntroLandingSound : MonoBehaviour
{
   public void PlayIntroLandingSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/CharacterSounds/Character_Intro_Landing", transform.position);
    }
}
