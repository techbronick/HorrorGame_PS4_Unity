using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoombieAi : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float enemySpeed=0.07f;
    public bool attackTrigger = false;
    public bool isAttacking = false;
    public AudioSource HurtSound1;
    public AudioSource HurtSound2;
    public AudioSource HurtSound3;
    public GameObject playerHurt;

    public int hurtGen;


   
    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(player.transform);                                                         
        if (attackTrigger == false)
        {
            enemySpeed = 0.007f;
            enemy.GetComponent<Animation>().Play("Z_Walk_InPlace");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed*Time.timeScale);
        }
        if (attackTrigger == true && isAttacking == false)
        {
            enemySpeed = 0;
            enemy.GetComponent<Animation>().Play("Z_Attack");
            StartCoroutine (InflictDamage());
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



    IEnumerator InflictDamage()
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
