using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossDeath : MonoBehaviour
{
    public int ZoombieHealth=65;
    public GameObject enemy;
    public int statusCheck;
    public AudioSource BackMus;
    public bool bossDamged;
    public GameObject Blood;
    public GameObject Blood2;
    public GameObject Blood3;

    void ZoombieDamage(int DamageAmount)
    {
        Blood.SetActive(true);
        Blood2.SetActive(true);
        Blood3.SetActive(true);
        bossDamged = true;
        ZoombieHealth -= DamageAmount;
        StartCoroutine(Damage1());
    }

    // Update is called once per frame
    void Update()
    {

        if (ZoombieHealth <= 0 && statusCheck == 0)
        {

            Blood.SetActive(false);
            Blood2.SetActive(false);
            Blood3.SetActive(false);
            this.GetComponent<FinalBossAI>().enabled = false;
            this.GetComponent<BossAttack>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            statusCheck=2;
          
            enemy.GetComponent<Animator>().Play("Death2");
          
            BackMus.Play();

        }
    }
    IEnumerator Damage1()
    {
        if (bossDamged == true && ZoombieHealth > 0)
        {

            this.GetComponent<FinalBossAI>().enabled = false;
            this.GetComponent<BossAttack>().enabled = false;

            enemy.GetComponent<Animator>().Play("React");
            yield return new WaitForSeconds(1f);
            bossDamged = false;

        }

        if (bossDamged == false && ZoombieHealth > 0)
        {
            this.GetComponent<FinalBossAI>().enabled = true;
            this.GetComponent<BossAttack>().enabled = true;

        }



    }
}
