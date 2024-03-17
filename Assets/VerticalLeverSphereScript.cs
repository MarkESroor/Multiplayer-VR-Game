using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLeverSphereScript : MonoBehaviour
{
    private float startX;

    private float angleX;
    private float angleY;
    private float angleZ;

    public AudioSource audioSource;
    public AudioClip LeverPulled;
    public GameObject Sphere;
    private bool isPulled = false;

    private float oldX, newX;
    private bool pulling, releasing = false;
    public GameObject lever;
    public GameObject parent;

    void Start()
    {
        startX = this.transform.localRotation.eulerAngles.x;
        
        angleX = this.transform.rotation.eulerAngles.x;
        angleY = this.transform.rotation.eulerAngles.y;
        angleZ = this.transform.rotation.eulerAngles.z;
    }

    public void setParent(){
        lever.transform.parent = parent.transform;
        lever.transform.eulerAngles = new Vector3(angleX, angleY, angleZ);
       /* lever.transform.localRotation = Quaternion.identity;
        lever.transform.rotation = Quaternion.identity;*/
    }
    void Update()
    {
        /*newX = this.transform.localRotation.eulerAngles.x;
        //if new angle is greater than old angle and greater than 45 and smaller than 90 then I'm pulling to the front
        if (newX > oldX && newX > 25 && newX < 90 && !pulling)
        {
            pulling = true;
            releasing = false;
            Vector3 direction = new Vector3(0.0f, 0.0f, -newX * 1f);
            Sphere.GetComponent<Rigidbody>().AddForce(direction);
        }
        //if new angle is smaller than old angle and greater than 30 and smaller than 90 then I'm releasing from the front
        else if (newX < oldX && newX > 25 && newX < 90 && !releasing)
        {
            pulling = false;
            releasing = true;
            // audioSource.PlayOneShot(LeverPulled);
        }
        //if new angle is smaller than old angle and greater than 270 and smaller than 315 then I'm pulling to the back
        else if (newX < oldX && newX > 270 && newX < 335 && !pulling)
        {
            pulling = true;
            releasing = false;
            Vector3 direction = new Vector3(0.0f, 0.0f, -(newX - 360) * 1f);
            Sphere.GetComponent<Rigidbody>().AddForce(direction);
        }
        //if new angle is greater than old angle and greater than 270 and smaller than 300 then I'm releasing from the back
        else if (newX > oldX && newX > 270 && newX < 335 && !releasing)
        {
            pulling = false;
            releasing = true;
            // audioSource.PlayOneShot(LeverPulled);
        }
        oldX = newX;*/


        /*float vertical = GetValue();
        if (vertical >= 45 && vertical <= 90 && !isPulled)
        {
            Pulled(vertical);
        }
        else if (vertical > 270 && vertical < 315 && !isPulled)
        {
            vertical = vertical - 360;
            Pulled(vertical);
        }
        else if ((vertical < 45 || vertical > 315) && isPulled) {
            Released();
        }*/
    }
    private float GetValue()
    {
        float currentX = this.transform.localRotation.eulerAngles.x;
        float xAngle = Mathf.Abs(startX - currentX);
        return xAngle;
    }
    private void Pulled(float angle)
    {
        isPulled = true;
        Vector3 direction = new Vector3(0.0f, 0.0f, angle * -1f);
        Sphere.GetComponent<Rigidbody>().AddForce(direction);
        //onPulled.Invoke();
    }

    private void Released() {
        isPulled = false;
        audioSource.PlayOneShot(LeverPulled);
    }
}
