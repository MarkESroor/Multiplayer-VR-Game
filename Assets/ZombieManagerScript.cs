using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZombieManagerScript : MonoBehaviour
{
    public GameObject Wave1, Wave2, Wave3, FinalTrigger,xrRig;
    public bool AllZombiesDead = false;
    public AudioSource BackGroundMusicPlayer;
    public AudioClip Victoryyy;
    public int count;
    public int CombinedHealth = 10;
    private bool switched;
    private GameObject[] Players,Sabers;
    public Transform[] spawnPoint;

    private bool Wave1Dead, Wave2Dead, Wave3Dead;
    private void Start()
    {
      
        switched = false;
        CombinedHealth = 10;
        FinalTrigger.SetActive(false);
        Wave2.SetActive(false);
        Wave3.SetActive(false);
    }

    public void increaseCount()
    {
        count++;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);

    }
    public void respawn()
    {
        //StartCoroutine(Wait()); //Wait 2s
        Players = GameObject.FindGameObjectsWithTag("Network Player");
        Sabers = GameObject.FindGameObjectsWithTag("Saber");
        xrRig = GameObject.FindGameObjectsWithTag("Player")[0];

        if (PhotonNetwork.IsMasterClient)
        {
            /*Players[0].transform.position = spawnPoint[0].transform.position;
            Players[0].transform.rotation = spawnPoint[0].transform.rotation;
            Players[1].transform.position = spawnPoint[1].transform.position;
            Players[1].transform.rotation = spawnPoint[1].transform.rotation;*/

            //move rig using is mine
            
        }
        xrRig.transform.position = spawnPoint[0].transform.position;
        xrRig.transform.rotation = spawnPoint[0].transform.rotation;

        Sabers[0].transform.position =
            spawnPoint[2].transform.position;
        Sabers[0].transform.rotation =
            spawnPoint[2].transform.rotation;
        Sabers[1].transform.position =
            spawnPoint[3].transform.position;
        Sabers[1].transform.rotation =
            spawnPoint[3].transform.rotation;

        CombinedHealth = 10;
    }
    void Update()
    {
        if (count==24 && !Wave1Dead) {
            Wave1Dead = true;
            Wave1.SetActive(false);
            Wave2.SetActive(true);
            count = 0;
        }
        if (count == 24&& !Wave2Dead)
        {
            Wave2Dead = true;
            Wave2.SetActive(false);
            Wave3.SetActive(true);
            count = 0;
        }
        if (count == 24 && !Wave3Dead)
        {
            Wave3Dead = true;
            Wave3.SetActive(false);
            count = 0;
        }
        if (Wave1Dead && Wave2Dead && Wave3Dead && !AllZombiesDead) {
            AllZombiesDead = true;
            BackGroundMusicPlayer.Stop();
            BackGroundMusicPlayer.PlayOneShot(Victoryyy);
            BackGroundMusicPlayer.loop = true;
            Debug.Log("*Scottish accent* FREEDOM!!");
            FinalTrigger.SetActive(true);
        }
    }
}
