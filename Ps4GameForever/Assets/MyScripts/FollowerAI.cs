using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerAI : MonoBehaviour
{
    public GameObject followerDestination;
    NavMeshAgent StalkerAgent;
    public GameObject enemy;
    public static bool isFollowing;


    public float enemySpeed = 0.07f;
    public bool attackTrigger = false;
    public static bool isAttacking = false;
    public static bool returningHome;

    public static bool atHome=false;


    public AudioSource HurtSound1;
    public AudioSource HurtSound2;
    public AudioSource HurtSound3;
    public GameObject playerHurt;

    public GameObject enemySpawn;

    public int hurtGen;


    // Start is called before the first frame update
    void Start()
    {
        StalkerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()

    {


        if (isFollowing == false)
        {

            enemy.GetComponent<Animation>().Play("Idle");

        }
        else if (attackTrigger == true && isAttacking == false)
        {

            enemySpeed = 0;
            enemy.GetComponent<Animation>().Play("Attack");

        }
        else

        {
            enemy.GetComponent<Animation>().Play("Walking");
            StalkerAgent.SetDestination(followerDestination.transform.position);

        }

        if (returningHome==true )
        {
         
            enemy.GetComponent<Animation>().Play("Walking");
            StalkerAgent.SetDestination(enemySpawn.transform.position);
        }

     


    }
    private void OnTriggerEnter(Collider other)
    {
        attackTrigger = true;
    
    }
    private void OnTriggerStay(Collider other)
    {
       
    }
    private void OnTriggerExit(Collider other)
    {
        attackTrigger = false;
        StartCoroutine(InflictDamage2());





    }


    IEnumerator InflictDamage2()
    {


        isAttacking = true;
        hurtGen = Random.Range(1, 4);
        if (hurtGen == 1)
        {
            HurtSound1.Play();

        }
        if (hurtGen == 2)
        {
            HurtSound2.Play();

        }
        if (hurtGen == 3)
        {
            HurtSound3.Play();

        }
        playerHurt.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        playerHurt.SetActive(false);
        yield return new WaitForSeconds(1.1f);
        GlobalHealth.currentHealth -= 5;
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;

    }


}


