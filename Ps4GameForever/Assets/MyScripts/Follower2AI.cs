// This is the Brain for the EXO Npc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PS4;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Follower2AI : MonoBehaviour
{

    Animator anim;      // the animator
    NavMeshAgent na;    // the nav mesh agent

    public Transform target;        // the target (which will be the player)
    public Transform targetbase1;    // the base (home) location of the enemy
    public float patrolSpeed = 2f;// The nav mesh agent's speed when patrolling.
    public float chaseSpeed = 3f;// The nav mesh agent's speed when chasing.
    public float patrolWaitTime = 1f;// The amount of time to wait when the patrol way point is reached.
    public Transform[] patrolWayPoints;// An array of transforms for the patrol route.
    public float patrolTimer;// A timer for the patrolWaitTime.
    public int wayPointIndex;// A counter for the way point array.
   


    public bool attackTrigger = false;
    public bool isAttacking = false;
    public int statusCheck;

    public AudioSource HurtSound1;
    public AudioSource HurtSound2;
    public AudioSource HurtSound3;
    public GameObject playerHurt;

    public AudioSource ZoombieBiting;

    public int hurtGen;
    public int playerId;


    // Use this for initialization
    void Start()
    {
        na = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Detect the player
        float enemydist = Vector3.Distance(target.transform.position,
            transform.position);

        // Set fake distance if game over so enemy goes away
    

        //enemydist = 10000; //??

        anim.SetFloat("EnemyDist", enemydist);

        // Distance to the home base of the Hammer Warrior NPC
        float basedist = Vector3.Distance(targetbase1.transform.position,
            transform.position);

        anim.SetFloat("BaseDist", basedist);

        // Determine which state Hammer Warrior is in
        AnimatorStateInfo asi = anim.GetCurrentAnimatorStateInfo(0);


    
        if (attackTrigger == true && isAttacking == false && asi.IsName("Attacking"))
        {

    
            na.isStopped = true;
            na.velocity = Vector3.zero;


            statusCheck = 2;
   

            StartCoroutine(InflictDamage5());
            ZoombieBiting.PlayOnGamepad(playerId);

        }
        
        // If Hammer Warrior is in Attack state

        if (asi.IsName("Patrol"))
        {

            Patrolling();

        }

        // If Hammer Warrior is in run state
        if (asi.IsName("Running"))
        {
            na.SetDestination(target.position);
            na.isStopped = false;
        }

        // If Hammer Warrior is in back to base state
        if (asi.IsName("Flee"))
        {
            na.SetDestination(targetbase1.position);
            na.isStopped = false;
        }
        if (asi.IsName("Idle"))
        {
            na.isStopped = true;
        }
        // If Hammer Warrior is in idle state

    }
    void Patrolling()
    {
        // Set an appropriate speed for the NavMeshAgent.
        na.speed = patrolSpeed;
        // If near the next waypoint or there is no destination...
        if (na.remainingDistance < na.stoppingDistance)
        {
            // ... increment the timer.
            patrolTimer += Time.deltaTime;
            // If the timer exceeds the wait time...
            if (patrolTimer >= patrolWaitTime)
            {
                // ... increment the wayPointIndex.
                if (wayPointIndex == patrolWayPoints.Length - 1)
                    wayPointIndex = 0;
                else
                    wayPointIndex++;
                // Reset the timer.
                patrolTimer = 0;
            }
        }
        else
            // If not near a destination, reset the timer.
            patrolTimer = 0;
        // Set the destination to the patrolWayPoint.
        na.destination = patrolWayPoints[wayPointIndex].position;
    }
    // Exo is attacking the Player. This is called from the Attack animation of
    // the Exo

    IEnumerator InflictDamage5()
    {
        isAttacking = true;
      
        hurtGen = Random.Range(1, 4);
        if (hurtGen == 1)
        {
            HurtSound1.PlayOnGamepad(playerId);

        }
        if (hurtGen == 2)
        {
            HurtSound2.PlayOnGamepad(playerId);

        }
        if (hurtGen == 3)
        {
            HurtSound3.PlayOnGamepad(playerId);

        }
        playerHurt.SetActive(true);
        PS4Input.PadSetVibration(playerId, 150, 150);
        yield return new WaitForSeconds(0.3f);
        playerHurt.SetActive(false);
        yield return new WaitForSeconds(1.1f);
     
        GlobalHealth.currentHealth -= 5;
        yield return new WaitForSeconds(0.2f);
        //PS4Input.PadSetVibration(0,0,0);
        isAttacking = false;




    }
    public void Hit()
    {
        Debug.Log("exo is attacking");
        
        // tell the attacked game object it has been attacked
       
    }



    // The player has attacked this Warrior
    // So fire the trigger 
    public void Attacked()
    {
        Debug.Log(name + " has been attacked");
        anim.SetTrigger("Attacked");
    }
    private void OnTriggerEnter(Collider other)
    {
        attackTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {

        attackTrigger = false;
    }

}


