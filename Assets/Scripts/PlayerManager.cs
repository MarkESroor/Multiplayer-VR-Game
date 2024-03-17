using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerManager : MonoBehaviour
{
    private GameObject spawnedPlayer;
    [SerializeField]
    private Transform[] spawnPoint;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        //if (PhotonNetwork.LevelLoadingProgress > 0 && PhotonNetwork.LevelLoadingProgress < 1)
        //{

        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            spawnedPlayer = PhotonNetwork.Instantiate("Network Player", spawnPoint[0].position, spawnPoint[0].rotation);
            spawnedPlayer.transform.parent = FindObjectOfType<XRRig>().transform;


        }
        else
        {
            XRRig xrrig = FindObjectOfType<XRRig>();
            xrrig.transform.position = spawnPoint[1].transform.position;
            xrrig.transform.rotation = spawnPoint[1].transform.rotation;

            spawnedPlayer = PhotonNetwork.Instantiate("Network Player", spawnPoint[1].position, spawnPoint[1].rotation);
            spawnedPlayer.transform.parent = FindObjectOfType<XRRig>().transform;


        }
    }

}
