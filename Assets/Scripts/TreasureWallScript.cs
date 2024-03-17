using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
public class TreasureWallScript : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip tada;
    public AudioClip wallsMoving8;
    public TreasureScript treasureScript;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public async void onGoalReached() {
        animator.SetBool("UnlockedTreasure", true);
        audioSource.PlayOneShot(tada);
        audioSource.PlayOneShot(wallsMoving8);
        //await Task.Delay(18000);
        // treasureScript.CollectTreasure();
    }
}
