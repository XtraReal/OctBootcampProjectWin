using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource ballSFX, pinSFX, uiSFX;

    [SerializeField] private AudioClip clipThrowStart, clipRoll, clipPinCollision, clipBallFall;
    [SerializeField] private AudioClip clipButtonHover, clipButtonPressed, clipSpare, clipStrike;

    // Start is called before the first frame update
    public void PlaySound(string soundClipName)
    {
        switch (soundClipName)
        {
            case "throw":
                ballSFX.PlayOneShot(clipThrowStart);
                break;
            case "roll":
                ballSFX.loop = true;
                ballSFX.clip = clipRoll;
                ballSFX.Play();
                break;
            case "collide":
                ballSFX.loop = false;
                ballSFX.Stop();
                pinSFX.PlayOneShot(clipPinCollision);
                break;
            case "ballFall":
                ballSFX.PlayOneShot(clipBallFall);
                break;
            case "strike":
                uiSFX.PlayOneShot(clipStrike);
                // Do Something
                break;
            case "spare":
                uiSFX.PlayOneShot(clipSpare);
                // Do Something
                break;
            case "buttonHover":
                uiSFX.PlayOneShot(clipButtonHover);
                // Do Something
                break;
            case "buttonClick":
                uiSFX.PlayOneShot(clipButtonPressed);
                break;
            default:
                
                //uiSFX.playOnAwake(clipBackground);
                break;
            
        }
    }
}
