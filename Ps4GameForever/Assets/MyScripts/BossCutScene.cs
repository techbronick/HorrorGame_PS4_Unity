using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossCutScene : MonoBehaviour
{

    public GameObject BossDestination2;
    NavMeshAgent FinalBossAgent2;

    public float enemySpeed = 0.07f;

    public GameObject StalkerEnemy2;
    public static bool isFollowingYou2;
    // Start is called before the first frame update
    void Start()
    {
        FinalBossAgent2 = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        StalkerEnemy2.GetComponent<Animator>().Play("Walk3");
        FinalBossAgent2.SetDestination(BossDestination2.transform.position);
    }


}
