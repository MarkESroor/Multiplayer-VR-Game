using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SphereMoveController : MonoBehaviour
{

    public Rigidbody rigid;
    private GameObject HorizontalLever;
    private GameObject VerticalLever;

    private bool Goal = false;
    private float HoriOldX, HoriNewX, VertiOldX, VertiNewX;
    private bool HoriPulling, HoriReleasing, VertiPulling, VertiReleasing = false;


    void Start()
    {
        HorizontalLever = GameObject.FindGameObjectsWithTag("LeverHori")[0];
        VerticalLever = GameObject.FindGameObjectsWithTag("LeverVerti")[0];
        HoriOldX = HorizontalLever.transform.localRotation.eulerAngles.x;
        VertiOldX = VerticalLever.transform.localRotation.eulerAngles.x;
    }

    void Update()
    {
        //Horizontal Lever Code
        HoriNewX = HorizontalLever.transform.localRotation.eulerAngles.x;
        //if new angle is greater than old angle and greater than 45 and smaller than 90 then I'm pulling to the right
        if (HoriNewX > HoriOldX && HoriNewX > 25 && HoriNewX < 90 && !HoriPulling)
        {
            HoriPulling = true;
            HoriReleasing = false;
            Vector3 direction = new Vector3(0.3f * HoriNewX * 1f, 0.0f, 0.0f);
            this.GetComponent<Rigidbody>().AddForce(direction);
        }
        //if new angle is smaller than old angle and greater than 30 and smaller than 90 then I'm releasing from the right
        else if (HoriNewX < HoriOldX && HoriNewX > 25 && HoriNewX < 90 && !HoriReleasing)
        {
            HoriPulling = false;
            HoriReleasing = true;
            // audioSource.PlayOneShot(LeverPulled);
        }
        //if new angle is smaller than old angle and greater than 270 and smaller than 315 then I'm pulling to the left
        else if (HoriNewX < HoriOldX && HoriNewX > 270 && HoriNewX < 335 && !HoriPulling)
        {
            HoriPulling = true;
            HoriReleasing = false;
            Vector3 direction = new Vector3(0.3f * (HoriNewX - 360) * 1f, 0.0f, 0.0f);
            this.GetComponent<Rigidbody>().AddForce(direction);
        }
        //if new angle is greater than old angle and greater than 270 and smaller than 300 then I'm releasing from the left
        else if (HoriNewX > HoriOldX && HoriNewX > 270 && HoriNewX < 335 && !HoriReleasing)
        {
            HoriPulling = false;
            HoriReleasing = true;
            // audioSource.PlayOneShot(LeverPulled);
        }
        HoriOldX = HoriNewX;


        //Vertical Lever code
        VertiNewX = VerticalLever.transform.localRotation.eulerAngles.x;
        //if new angle is greater than old angle and greater than 45 and smaller than 90 then I'm pulling to the right
        if (VertiNewX > VertiOldX && VertiNewX > 25 && VertiNewX < 90 && !VertiPulling)
        {
            VertiPulling = true;
            VertiReleasing = false;
            Vector3 direction = new Vector3(0.0f, 0.0f, -0.3f * VertiNewX * 1f);
            this.GetComponent<Rigidbody>().AddForce(direction);
        }
        //if new angle is smaller than old angle and greater than 30 and smaller than 90 then I'm releasing from the right
        else if (VertiNewX < VertiOldX && VertiNewX > 25 && VertiNewX < 90 && !VertiReleasing)
        {
            VertiPulling = false;
            VertiReleasing = true;
            // audioSource.PlayOneShot(LeverPulled);
        }
        //if new angle is smaller than old angle and greater than 270 and smaller than 315 then I'm pulling to the left
        else if (VertiNewX < VertiOldX && VertiNewX > 270 && VertiNewX < 335 && !VertiPulling)
        {
            VertiPulling = true;
            VertiReleasing = false;
            Vector3 direction = new Vector3(0.0f, 0.0f, -0.3f * (VertiNewX - 360) * 1f);
            this.GetComponent<Rigidbody>().AddForce(direction);
        }
        //if new angle is greater than old angle and greater than 270 and smaller than 300 then I'm releasing from the left
        else if (VertiNewX > VertiOldX && VertiNewX > 270 && VertiNewX < 335 && !VertiReleasing)
        {
            VertiPulling = false;
            VertiReleasing = true;
            // audioSource.PlayOneShot(LeverPulled);
        }
        VertiOldX = VertiNewX;
    }
}
