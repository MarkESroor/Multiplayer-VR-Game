using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class steeringwheel : MonoBehaviour
{

    public GameObject controller;
    public Quaternion originalRotationValue; // declare this as a Quaternion
    float rotationResetSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        originalRotationValue = transform.rotation; // save the initial rotation
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   // override onSelectE
   public void returnDefault()
   {
      // controller.transform.rotation= Quaternion.Euler (0, 0, 9);
      //controller.transform.rotation = Quaternion.identity;
        
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time * rotationResetSpeed); 
   }
}



/*
 public Quaternion originalRotationValue; // declare this as a Quaternion
 float rotationResetSpeed = 1.0f;
 
 void Start () {
     originalRotationValue = transform.rotation; // save the initial rotation
 }
 
 void Update () {
     //rotate selected piece
     if(isSelected)
         gameObject.transform.Rotate(0, 1, 0); // this rotates only 1 degree!
     //otherwise rotate it back to its original rotation
     else
         transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time * rotationResetSpeed); 
 }*/
