using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiactivateFollower : MonoBehaviour
{

    public GameObject enemySpawn;
    public GameObject zoombieHuntsAgainTrig;

   void OnTriggerEnter(Collider other)
    {
        MazeFolloweAi.returningHome2 = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
   
        enemySpawn.SetActive(true);
        zoombieHuntsAgainTrig.SetActive(true);



    }
}
