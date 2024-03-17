using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    

    public AudioSource audioSource;
    public AudioClip[] audios;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playRockSound(){
        int number = Random.Range(0,4);
        audioSource.PlayOneShot(audios[number]);

    }
}
