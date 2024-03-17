using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
using Photon.Pun;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float forceAmount = 500f;
    //Transform target;
    NavMeshAgent agent;
    public AudioSource audioSource;
    public AudioClip Nope, DyingSound, Swoosh;
    public bool Alive = true;
    public CapsuleCollider CapsuleCollider;
    public static GameObject[] Players;
    public GameObject Zombie;
    ZombieManagerScript zombieManager;
    private float distanceToTarget = 100000000;
    private GameObject targetPlayer;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        zombieManager = GameObject.FindObjectOfType<ZombieManagerScript>();
        Players = GameObject.FindGameObjectsWithTag("Network Player");
        foreach (GameObject p in Players) {
            float distanceToCurrentTarget = new Vector3(this.transform.position.x - p.transform.position.x
                , this.transform.position.y - p.transform.position.y
                , this.transform.position.z - p.transform.position.z).magnitude;
            //checks if this player is closer than the other player AND if the player is even alive

            if (distanceToCurrentTarget < distanceToTarget && p.GetComponent<PlayerManagerForStats>().Alive) {
                targetPlayer = p;
                distanceToTarget = distanceToCurrentTarget;
            }
        }
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

   
    // public void Hit(Arrow arrow)
    // {
    //     //ApplyForce(arrow.transform.forward);
    // }
    /*private void ApplyForce(Vector3 direction)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(direction * forceAmount);
        this.animator.enabled = false;
        Alive = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }*/
    public void OnTriggerEnter(Collider other)
    {
        //The original arrow hit functionality is commented above in case this one's a bust
        //Why isn't it all commented? 3ashan interface el IArrowHittable requires function "Hit" to exist.
        //So I simply commeneted its content and the ApplyForce function. Shouldn't do any harm.
        if (other.gameObject.tag == "Saber" && Alive) {
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(Swoosh);
            Zombie.GetComponent<PhotonView>().RPC("heckingDie", RpcTarget.All);
            //heckingDie();



            //this.animator.enabled = false;
            //Alive = false;
            //gebt el capsule collider ka public object (see line 14) keda to make sure I'm disabling the correct collider
            //CapsuleCollider.enabled = false;
            //Add force hena...here's what I did: gebt el rigidbody bta3 el zombie, gebt direction el arrow, 3amalt force in the arrow's direction on the rigidbody. Theoretically, it should work like a charm
            // Rigidbody rigidbody = GetComponent<Rigidbody>();
            // Vector3 direction = other.gameObject.transform.forward;
            // rigidbody.AddForce(direction * forceAmount);
        }
    }

    void Update()
    {
        Players = GameObject.FindGameObjectsWithTag("Network Player");
        foreach (GameObject p in Players)
        {
            float distanceToCurrentTarget = new Vector3(this.transform.position.x - p.transform.position.x
                , this.transform.position.y - p.transform.position.y
                , this.transform.position.z - p.transform.position.z).magnitude;
            //checks if this player is closer than the other player AND if the player is even alive
            if (distanceToCurrentTarget < distanceToTarget && p.GetComponent<PlayerManagerForStats>().Alive)
            {
                targetPlayer = p;
                distanceToTarget = distanceToCurrentTarget;
            }
        }
        float distance = Vector3.Distance(targetPlayer.transform.position, transform.position);

        if (distance <= lookRadius && Alive)
        {
            //start running towards player
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsKicking", false);
            agent.SetDestination(new Vector3(targetPlayer.transform.position.x, targetPlayer.transform.position.y, targetPlayer.transform.position.z));


            if (distance <= agent.stoppingDistance)
            {
                //start attacking player
                FaceTarget();
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsKicking", true);
            }
        }
        else if(distance > lookRadius && Alive)
        {
            //do idle animation
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsIdle", true);
            agent.SetDestination(gameObject.transform.position);
        }
    }
    void FaceTarget() {
        Players = GameObject.FindGameObjectsWithTag("Network Player");
        Vector3 direction = (targetPlayer.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f);
    }
    public void AttackTarget() {
        //make sure target didn't run away between the start of the animation and the attack instance
        float distance = Vector3.Distance(targetPlayer.transform.position, transform.position);
        GameObject currentPlayer = targetPlayer;
        if (distance <= agent.stoppingDistance && Alive) {
            if (zombieManager.CombinedHealth > 0) {
                zombieManager.CombinedHealth--;
                audioSource.PlayOneShot(Nope);
                currentPlayer.GetComponent<PlayerManagerForStats>().ByeHaveANiceDay();
                //checks if the player died to go target another player
                if (!currentPlayer.GetComponent<PlayerManagerForStats>().Alive) {
                    //if the player is dead, maximize the current distance to be able to find the other player in the update method
                    distanceToTarget = 100000000;
                }
            }
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    [PunRPC]
    public async void heckingDie()
    {

        this.animator.enabled = false;
        Alive = false;
        audioSource.PlayOneShot(DyingSound);
        Debug.Log("I DIED!!");
        Debug.Log("Current Count is: " + zombieManager.count.ToString());
        zombieManager.increaseCount();
        //await Task.Delay(5000);

        //PhotonNetwork.Destroy(this.GetComponent<PhotonView>()) ;

        //Destroy(Zombie);
        //gebt el capsule collider ka public object (see line 14) keda to make sure I'm disabling the correct collider
        // CapsuleCollider.enabled = false;
    }
}
