using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerDeath : MonoBehaviour
{
    public int ZoombieHealth=25;
    public GameObject enemy;
    public int statusCheck;
    public AudioSource BackMus;
  



    void ZoombieDamage(int DamageAmount)
    {


        ZoombieHealth -= DamageAmount;
    }

    // Update is called once per frame
    void Update()
    {

        if (ZoombieHealth <= 0 && statusCheck == 0)
        {
            FollowerAI.returningHome = false;
            this.GetComponent<FollowerAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            statusCheck=2;
         
            enemy.GetComponent<Animation>().Stop("Walking");
            enemy.GetComponent<Animation>().Play("Death");
         
            BackMus.Play();

        }
    }
}
