using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWallScript : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource,pirate2DSource;
    public AudioClip wallsMoving, FallenTrap,firstPirateAudio;
    public GameObject LeftLever, RightLever;
    private bool LeftPulled, RightPulled, alreadyPulled;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void LeverPulled(GameObject Lever) {
        if (Lever == LeftLever) {
            LeftPulled = true;
        }
        else if (Lever == RightLever) {
            RightPulled = true;
        }
        if (LeftPulled && RightPulled && !alreadyPulled) {
            animator.SetBool("LaqadWaqa3naFelFa5", true);
            audioSource.PlayOneShot(wallsMoving);
            pirate2DSource.PlayOneShot(firstPirateAudio);
            alreadyPulled = true;
            
        }
    }
    public void LeverReleased(GameObject Lever) {
        if (Lever == LeftLever) {
            LeftPulled = false;
        }
        else if (Lever == RightLever) {
            RightPulled = false;
        }
    }
    public void PlayTrapSound() {
        audioSource.PlayOneShot(FallenTrap);
    }
}
