using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoombieDead : MonoBehaviour
{
    public int ZoombieHealth=20;
    public GameObject enemy;
    public int statusCheck;
    public AudioSource JumpScareMus;
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
            this.GetComponent<ZoombieAi>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            statusCheck=2;
            enemy.GetComponent<Animation>().Stop("Z_Walk_InPlace");
            enemy.GetComponent<Animation>().Play("Z_FallingBack");
            JumpScareMus.Stop();
            BackMus.Play();

        }
    }
}
