using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PS4;
public class BossAttack : MonoBehaviour
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

    public int playerId;

    // Update is called once per frame
    void Update()
    {
        if (attackTrigger == true && isAttacking == false)
        {

            this.GetComponent<FinalBossAI>().enabled = false;

            statusCheck = 2;


            enemy.GetComponent<Animator>().Play("Attack2");
            StartCoroutine(InflictDamage3());

            ZoombieAttack.PlayOnGamepad(playerId);
            BackMus.Play();

        }
        else if(attackTrigger==false)
        {
            this.GetComponent<FinalBossAI>().enabled = true;
           // ZoombieAttack.PauseOnGamepad(playerId);

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
    IEnumerator InflictDamage3()
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
        GlobalHealth.currentHealth -= 10;
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;




    }
}
