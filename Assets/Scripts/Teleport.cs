using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    
    IEnumerator Wait()
    {
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        GetComponent<Renderer>().enabled = true;
    }

    public void Disappear()
    {
        StartCoroutine(Wait());
    }

}
