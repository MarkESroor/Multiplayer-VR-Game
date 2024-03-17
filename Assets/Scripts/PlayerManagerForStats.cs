using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManagerForStats : MonoBehaviour
{
    #region Singleton
    //i honestly do not remember why we use this instance...idek if it's used anywhere
    public static PlayerManagerForStats instance;
    //public int Health = 5;
    [SerializeField]
    private Transform[] spawnPoint;
    // private Canvas canvas;
    private GameObject canvas;
    private TMPro.TMP_Text DeadText;
    private TMPro.TMP_Text HpText;
    public bool Alive = true;
    private GameObject[] Players;
    private bool inNightScene;
    ZombieManagerScript zombieManager;
    public bool switched;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
        if (GameObject.FindGameObjectsWithTag("ZombieBoi").Length != 0)
        {
            zombieManager = GameObject.FindObjectOfType<ZombieManagerScript>();
            zombieManager.CombinedHealth = 10;
            switched = true;
            canvas = GameObject.FindGameObjectsWithTag("Player Canvas")[0];
            HpText = canvas.transform.Find("Health Text").GetComponent<TextMeshProUGUI>();
            DeadText = canvas.transform.Find("Dead Text").GetComponent<TextMeshProUGUI>();
            inNightScene = true;
        }
    }
    void Update()
    {
        if (inNightScene)
        {
            HpText.text = "Health: " + zombieManager.CombinedHealth;
        }
    }

    public void ByeHaveANiceDay() {
        if (inNightScene)
        {
            Players = GameObject.FindGameObjectsWithTag("Network Player");
            HpText.text = "Health: " + zombieManager.CombinedHealth;
            if (zombieManager.CombinedHealth <= 0)
            {
                zombieManager.CombinedHealth = 0;
                Alive = false;
                //if (CheckIfAllPlayersAreDead(Players))
                //{
                    DeadText.text = "You're both down. Restarting...";
                    DeadText.gameObject.SetActive(true);
                    zombieManager.respawn();

                StartCoroutine(Wait()); //Wait 2s
                Alive = true;
                DeadText.gameObject.SetActive(false);



                //Players[0].transform.position = spawnPoint[0].transform.position;
                //Players[0].transform.rotation = spawnPoint[0].transform.rotation;
                //Players[0].GetComponent<PlayerManagerForStats>().Health = 5;
                //Players[0].GetComponent<PlayerManagerForStats>().Alive = true;

                //Players[1].transform.position = spawnPoint[1].transform.position;
                //Players[1].transform.rotation = spawnPoint[1].transform.rotation;
                //Players[1].GetComponent<PlayerManagerForStats>().Health = 5;
                //Players[1].GetComponent<PlayerManagerForStats>().Alive = true;

                //}
                /*else
                {
                    DeadText.text = "You're down!\n Wait for your partner to revive you";
                    DeadText.gameObject.SetActive(true);

                    if (!Players[0].GetComponent<PlayerManagerForStats>().Alive)
                    {
                        StartCoroutine(Wait()); //Wait 2s
                        Players[0].transform.position = spawnPoint[0].transform.position;
                        Players[0].transform.rotation = spawnPoint[0].transform.rotation;
                        Players[0].GetComponent<PlayerManagerForStats>().Health = 5;
                        Players[0].GetComponent<PlayerManagerForStats>().Alive = true;
                    }

                    else
                    {
                        StartCoroutine(Wait()); //Wait 2s
                        Players[1].transform.position = spawnPoint[1].transform.position;
                        Players[1].transform.rotation = spawnPoint[1].transform.rotation;
                        Players[1].GetComponent<PlayerManagerForStats>().Health = 5;
                        Players[1].GetComponent<PlayerManagerForStats>().Alive = true;
                    }

                }*/
            }
        }
    }

    /*public bool CheckIfAllPlayersAreDead(GameObject[] players)
    {
        if (inNightScene)
        {
            foreach (GameObject p in players)
            {
                if (!p.GetComponent<PlayerManagerForStats>().Alive)
                {
                    return p;
                }
            }
            return true;
        }
        return false;
    }*/
    #endregion

    //IEnumerator Dead()
    //{
    //    GetComponent<Renderer>().enabled = false;
    //    yield return new WaitForSeconds(5);
    //    GetComponent<Renderer>().enabled = true;
    //}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);

    }

    public GameObject player;
}
