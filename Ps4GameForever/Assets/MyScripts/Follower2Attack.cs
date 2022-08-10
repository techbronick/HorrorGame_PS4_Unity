using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower2Attack : MonoBehaviour
{

    public GameObject enemy;
    public int statusCheck;
    public AudioSource BackMus;

   
    public AudioSource HurtSound1;
    public AudioSource HurtSound2;
    public AudioSource HurtSound3;
    public GameObject playerHurt;

    public int hurtGen;

    public bool attackTrigger = false;
    public bool isAttacking = false;
    public AudioSource ZoombieAttack;

    // Update is called once per frame
    void Update()
    {
        if (attackTrigger == true && isAttacking == false)
        {

            this.GetComponent<Follower2AI>().enabled = false;

            statusCheck = 2;


            enemy.GetComponent<Animator>().Play("Attacking1");
            StartCoroutine(InflictDamage5());

            ZoombieAttack.Play();
            BackMus.Play();

        }
    else if(attackTrigger==false)
        {
       
            this.GetComponent<Follower2AI>().enabled = true;
            ZoombieAttack.Stop();

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        attackTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
       
        attackTrigger = false;
    }
    IEnumerator InflictDamage5()
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
