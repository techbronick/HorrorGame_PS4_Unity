using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MazeFolloweAi : MonoBehaviour
{
    public GameObject Destination;
    NavMeshAgent Agent;

    public float enemySpeed = 0.07f;

    public GameObject StalkerEnemy;
    public static bool startedfollow=false;
    public static bool returningHome2;


    public GameObject enemySpawn;
 

    // Start is called before the first frame update
    void Start()
    {
      Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()

    {


        if (startedfollow == false)
        {

            StalkerEnemy.GetComponent<Animator>().Play("Idle");

        }
        
        else 
        {
            StalkerEnemy.GetComponent<Animator>().Play("Walk");
            Agent.SetDestination(Destination.transform.position);

        }



        if (returningHome2 == true)
        {

            StalkerEnemy.GetComponent<Animator>().Play("Walk");
            Agent.SetDestination(enemySpawn.transform.position);
        }





    }


   

  


}


