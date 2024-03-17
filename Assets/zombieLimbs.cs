using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieLimbs : MonoBehaviour, IArrowHittable
{

    public EnemyController enemyController;
    public void Hit(Arrow arrow)
    {
        Debug.Log("Hit by arrow");
       // arrow.transform.parent = this.gameObject.transform;
        enemyController.heckingDie();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Saber" && collision.gameObject.GetComponent<LightSaber2>().isOn)
            //|| collision.gameObject.layer == 16
        {
            Debug.Log("Hit by Saber");
            //Debug.Log("saber hit zombie");
            enemyController.heckingDie();
            /*
            collision.gameObject.GetComponent<Animator>().enabled = false;
            collision.gameObject.GetComponentInChildren<EnemyController>().Alive = false;
            Vector3 direction = new Vector3(gameObject.transform.position.x - collision.gameObject.transform.position.x
                , gameObject.transform.position.y - collision.gameObject.transform.position.y
                , gameObject.transform.position.z - collision.gameObject.transform.position.z);
            collision.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 0) * 500f);
            //collision.gameObject.GetComponent<Animator>().SetBool("IsKilled", true);
            */
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
