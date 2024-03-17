using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour
{
    public Rigidbody rigid;
    public float horizontal;
    public float vertical;
    public float speed = 10f;
    private bool []pushed = { false, false, false, false };


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical);
        rigid.AddForce(direction * speed);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button1"))
        {
            print("Clicked button1!!");
            pushed[0] = true;


        }

        if (other.CompareTag("Button2"))
        {
            print("Clicked button2!!");
            pushed[1] = true;


        }

        if (other.CompareTag("Button3"))
        {
            print("Clicked button3!!");
            pushed[2] = true;


        }

        if (other.CompareTag("Button4"))
        {
            print("Clicked button4!!");
            pushed[3] = true;


        }

        if (pushed[0] == true && pushed[1] == true && pushed[2] == true && pushed[3] == true)
            print("All are clicked");

    }
}
