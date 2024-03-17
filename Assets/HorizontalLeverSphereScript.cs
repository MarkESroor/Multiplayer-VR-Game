using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalLeverSphereScript : MonoBehaviour
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
        oldX = this.transform.localRotation.eulerAngles.x;

        angleX = this.transform.rotation.eulerAngles.x;
        angleY = this.transform.rotation.eulerAngles.y;
        angleZ = this.transform.rotation.eulerAngles.z;
    }

    public void setParent(){
        lever.transform.parent = parent.transform;
        lever.transform.eulerAngles = new Vector3(angleX, angleY, angleZ);
        /*lever.transform.localRotation = Quaternion.identity;
        lever.transform.rotation = Quaternion.identity;*/
    }
    void Update()
    {
        /*newX = this.transform.localRotation.eulerAngles.x;
        //if new angle is greater than old angle and greater than 45 and smaller than 90 then I'm pulling to the right
        if (newX > oldX && newX > 25 && newX < 90 && !pulling) {
            pulling = true;
            releasing = false;
            Vector3 direction = new Vector3(newX * 1f, 0.0f, 0.0f);
            Sphere.GetComponent<Rigidbody>().AddForce(direction);
        }
        //if new angle is smaller than old angle and greater than 30 and smaller than 90 then I'm releasing from the right
        else if (newX < oldX && newX > 25 && newX < 90 && !releasing) {
            pulling = false;
            releasing = true;
            // audioSource.PlayOneShot(LeverPulled);
        }
        //if new angle is smaller than old angle and greater than 270 and smaller than 315 then I'm pulling to the left
        else if (newX < oldX && newX > 270 && newX < 335 && !pulling) {
            pulling = true;
            releasing = false;
            Vector3 direction = new Vector3((newX - 360) * 1f, 0.0f, 0.0f);
            Sphere.GetComponent<Rigidbody>().AddForce(direction);
        }
        //if new angle is greater than old angle and greater than 270 and smaller than 300 then I'm releasing from the left
        else if (newX > oldX && newX > 270 && newX < 335 && !releasing) {
            pulling = false;
            releasing = true;
            // audioSource.PlayOneShot(LeverPulled);
        }
        oldX = newX;*/


        /*float horizontal = GetValue();
        if (horizontal >= 45 && horizontal <= 90 && !isPulled)
        {
            Pulled(horizontal);
        }
        else if (horizontal > 270 && horizontal < 315 && !isPulled)
        {
            horizontal = horizontal - 360;
            Pulled(horizontal);
        }
        else if ((horizontal < 45 && horizontal > 0 || horizontal > -45 && horizontal < 0) && isPulled)
        {
            Released();
        }
        else if (horizontal > 315 && horizontal < 360 && isPulled) {
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
        //audioSource.PlayOneShot(LeverPulled);
        Vector3 direction = new Vector3(angle*0.1f, 0.0f, 0.0f);
        Sphere.GetComponent<Rigidbody>().AddForce(direction);
        //onPulled.Invoke();
        Debug.Log(isPulled);
    }
    private void Released()
    {
        isPulled = false;
        audioSource.PlayOneShot(LeverPulled);
        Debug.Log(isPulled);

    }
}
