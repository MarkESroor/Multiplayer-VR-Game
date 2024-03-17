using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SphereSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    private GameObject sphere;
   // private bool spawned=false;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            sphere = PhotonNetwork.Instantiate("Sphere", spawnPoint.position, spawnPoint.rotation);
          
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
