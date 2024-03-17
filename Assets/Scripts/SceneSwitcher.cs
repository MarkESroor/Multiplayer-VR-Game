using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    int collisionCount=0;
    bool switched = true;
    private void Update()
    {
        if (collisionCount == 2 && switched)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.Log("switching to Night Island!");
                PhotonNetwork.AutomaticallySyncScene = true;
                PhotonNetwork.LoadLevel("Night Island");
                switched = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
 
        if (other.gameObject.CompareTag("Network Player"))
        {
            collisionCount++;
      
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Network Player"))
        {
            collisionCount--;
        }
    }
    

}
