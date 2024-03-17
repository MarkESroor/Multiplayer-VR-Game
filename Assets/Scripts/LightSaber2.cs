using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber2 : MonoBehaviour
{
    public AudioClip beamOn;
    public GameObject lightSource;

    private GameObject laser1, laser2;
    private Vector3 fullsize;

    public bool isOn = false;
    private AudioSource audioSource;
    private Animator animator;

    private Vector3 OldLocation, NewLocation;
    public bool tryingActivate=false;

    // Start is called before the first frame update
    void Start()
    {
        laser1 = transform.Find("SingleLine-LightSaber1").gameObject;
        laser2 = transform.Find("SingleLine-LightSaber2").gameObject;
        lightSource.SetActive(false);
        fullsize = laser1.transform.localScale;
        laser1.transform.localScale = new Vector3(fullsize.x, 0, fullsize.z);
        laser2.transform.localScale = new Vector3(fullsize.x, 0, fullsize.z);
        audioSource = GetComponent<AudioSource>();
        OldLocation = laser1.transform.localScale;
    }

  

    void Update()
    {
        if (tryingActivate){
            AcitvateBeam();
            tryingActivate=false;
        }
        if (isOn) {
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        if (!isOn) {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
        NewLocation = laser1.transform.localScale;
        OldLocation = NewLocation;

    }

    public void AcitvateBeam()
    {
        audioSource.Play();
        if (!isOn)
        {
            isOn = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
            lightSource.SetActive(true);
            audioSource.PlayOneShot(beamOn);
            while (laser1.transform.localScale.y < fullsize.y)
            {
                laser1.transform.localScale += new Vector3(0, 0.00001f, 0);
                laser2.transform.localScale += new Vector3(0, 0.00001f, 0);
            }
        }
        else
        {
            isOn = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            lightSource.SetActive(false);
            audioSource.Stop();
            while (laser1.transform.localScale.y > 0)
            {
                laser1.transform.localScale -= new Vector3(0, 0.00001f, 0);
                laser2.transform.localScale -= new Vector3(0, 0.00001f, 0);
            }
            if (laser1.transform.localScale.y < 0 || laser2.transform.localScale.y < 0) {
                laser1.transform.localScale = new Vector3(laser1.transform.localScale.x, 0, laser1.transform.localScale.z);
                laser2.transform.localScale = new Vector3(laser1.transform.localScale.x, 0, laser1.transform.localScale.z);
            }
        }
    }

/*    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ZombieBoi")
        {
            collision.gameObject.GetComponent<Animator>().enabled = false;
            collision.gameObject.GetComponentInChildren<EnemyController>().Alive = false;
            
            // Vector3 direction = new Vector3(gameObject.transform.position.x - collision.gameObject.transform.position.x
            //     , gameObject.transform.position.y - collision.gameObject.transform.position.y
            //     , gameObject.transform.position.z - collision.gameObject.transform.position.z);
            // collision.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 0) * 500f);


            //collision.gameObject.GetComponent<Animator>().SetBool("IsKilled", true);
        }
    }*/
    /*public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "ZombieBoi" 
            //|| collision.gameObject.layer == 16
            ){
            //Debug.Log("saber hit zombie");
            collision.gameObject.GetComponent<Animator>().enabled = false;
            collision.gameObject.GetComponentInChildren<EnemyController>().Alive = false;
            Vector3 direction = new Vector3(gameObject.transform.position.x - collision.gameObject.transform.position.x
                , gameObject.transform.position.y - collision.gameObject.transform.position.y
                , gameObject.transform.position.z - collision.gameObject.transform.position.z);
            collision.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0,0) * 500f);
            //collision.gameObject.GetComponent<Animator>().SetBool("IsKilled", true);
        }
    }*/

}
