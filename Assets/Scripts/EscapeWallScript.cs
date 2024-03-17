using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeWallScript : MonoBehaviour
{

    public Animator animator;
    public GameObject GButton, OButton, LButton, DButton;
    public AudioSource audioSource;
    public AudioSource pirateAudioSource;
    public AudioClip wallsMoving, rightButton, wrongButton, secondPirateTalk;

    private bool[] GOLD = { false, false, false, false };
    
    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    public void ButtonManager(GameObject button) {
        audioSource.PlayOneShot(rightButton);
        switch (button.gameObject.tag) {
           

            case "GButton":
                {
                    //if all buttons are off, 1st one becomes on, else, everything is turned off
                    if (!GOLD[0] && !GOLD[1] && !GOLD[2] && !GOLD[3])
                    {
                        GOLD[0] = true;
                        //add sounds?
                    }
                    else { GOLD[0] = true; GOLD[1] = false; GOLD[2] = false; GOLD[3] = false; 
                    
                    
                    }
                    return;
                }
            case "OButton":
                {
                    //if all buttons are off except for the 1st, 2nd one becomes on, else, everything is turned off
                    if (GOLD[0] && !GOLD[1] && !GOLD[2] && !GOLD[3])
                    {
                        GOLD[1] = true;
                        //add sounds?
                    }
                    else { GOLD[0] = false; GOLD[1] = false; GOLD[2] = false; GOLD[3] = false; 

                    }
                    return;
                }
            case "LButton":
                {
                    //if all buttons are off except for the 1st & 2nd, 3rd one becomes on, else, everything is turned off
                    if (GOLD[0] && GOLD[1] && !GOLD[2] && !GOLD[3])
                    {
                        GOLD[2] = true;
                        //add sounds?
                    }
                    else { GOLD[0] = false; GOLD[1] = false; GOLD[2] = false; GOLD[3] = false; }
                    return;
                }
            case "DButton":
                {
                    //if all buttons are on except for the 4th, 4th one becomes on and open the escape walls, else, everything is turned off
                    if (GOLD[0] && GOLD[1] && GOLD[2] && !GOLD[3])
                    {
                        GOLD[3] = true;
                        animator.SetBool("Efta7YaSemsem", true);
                        audioSource.PlayOneShot(wallsMoving);
                        pirateAudioSource.PlayOneShot(secondPirateTalk);
                    }
                    else { GOLD[0] = false; GOLD[1] = false; GOLD[2] = false; GOLD[3] = false; }
                    return;
                }
            case "Wrong Button":
                {
                    GOLD[0] = false; GOLD[1] = false; GOLD[2] = false; GOLD[3] = false;
                    audioSource.PlayOneShot(wrongButton);
                    return;
                }
        }
    }
}
