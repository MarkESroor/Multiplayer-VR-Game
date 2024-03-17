using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ownership : MonoBehaviour
{
    public PhotonView photon;
    // Start is called before the first frame update
    void Start()
    {
        photon.RequestOwnership();
        Debug.Log("took ownership");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
