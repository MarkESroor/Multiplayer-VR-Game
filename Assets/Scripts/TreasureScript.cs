using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
public class TreasureScript : MonoBehaviour
{
    public GameObject Treasure, Light1, Light2, ExitPortal;
    public AudioSource audioSource,pirateAudioSource;
    public AudioClip TreasureCollectSound,thirdPirateTalk,wallsHit;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public async void CollectTreasure()
    {
        audioSource.PlayOneShot(TreasureCollectSound);
        Treasure.gameObject.SetActive(false);
        Light1.SetActive(false);
        Light2.SetActive(false);
        pirateAudioSource.PlayOneShot(thirdPirateTalk);
        await Task.Delay(18000);
        //play pirate sound
        //delay until pirate sound finishes
        audioSource.PlayOneShot(wallsHit);
        ExitPortal.SetActive(true);
        //activate the exit portal functionality
    }
}
