using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalBossAI : MonoBehaviour
{
    public GameObject BossDestination;
    NavMeshAgent FinalBossAgent;

    public float enemySpeed = 0.07f;

    public GameObject StalkerEnemy;
    public static bool isFollowingYou;




    // Start is called before the first frame update
    void Start()
    {
      FinalBossAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()

    {


        if (isFollowingYou == false)
        {

            StalkerEnemy.GetComponent<Animator>().Play("Idle");

        }
        
        else 
        {
            StalkerEnemy.GetComponent<Animator>().Play("Walk2");
            FinalBossAgent.SetDestination(BossDestination.transform.position);

        }



     

       



    }


   

  


}


