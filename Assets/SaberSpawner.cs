using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SaberSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform spawnPoint2;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject saber1 = PhotonNetwork.Instantiate("LightSaber", spawnPoint.position, spawnPoint.rotation);
            GameObject saber2 = PhotonNetwork.Instantiate("LightSaber", spawnPoint2.position, spawnPoint2.rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
