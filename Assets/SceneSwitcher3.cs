using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class SceneSwitcher3 : MonoBehaviour
{
    int collisionCount = 0;
    bool switched = true;
   // public GameObject waitCanvas;

    private void Start()
    {
       // waitCanvas.SetActive(false);
    }
    private void Update()
    {
        if (collisionCount == 2 && switched)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.Log("switching to credits scene...");
                PhotonNetwork.AutomaticallySyncScene = true;
                //instead of the below line, make a scene for the credits and replace "room" with that scene name
                PhotonNetwork.LoadLevel("Credits");
                switched = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Network Player"))
        {
            collisionCount++;
           /* if (collisionCount == 1)
            {
                waitCanvas.SetActive(true);
            }
            else
            {
                waitCanvas.SetActive(false);
            }*/
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Network Player"))
        {
            collisionCount--;
           // waitCanvas.SetActive(false);
        }
    }
}
