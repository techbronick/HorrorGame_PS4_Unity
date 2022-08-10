using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoombie2Death : MonoBehaviour
{
    public int ZoombieHealth = 20;
    public GameObject enemy;
    public int statusCheck1;
    public AudioSource BackMus;
    public AudioSource ZoombieDead;
    public GameObject blood;
    public bool reaction;

    void ZoombieDamage(int DamageAmount)
    {

        blood.SetActive(true);
        ZoombieHealth -= DamageAmount;
        reaction = true;
        StartCoroutine(Damage2());
    }

    // Update is called once per frame
    void Update()
    {

        if (ZoombieHealth <= 0 && statusCheck1 == 0)
        {
            blood.SetActive(false);
            this.GetComponent<Follower2AI>().enabled = false;
           

            statusCheck1 = 2;
            ZoombieDead.Play();
            enemy.GetComponent<Animator>().Play("Dead");

            BackMus.Play();

        }
    }
    IEnumerator Damage2()
    {
        if (reaction == true && ZoombieHealth > 0)
        {

            this.GetComponent<Follower2AI>().enabled = false;
            
            enemy.GetComponent<Animator>().Play("Reaction");
            yield return new WaitForSeconds(2f);
            reaction = false;

        }

        if (reaction == false && ZoombieHealth > 0)
        {
            enemy.GetComponent<Animator>().Play("Running");
            this.GetComponent<Follower2AI>().enabled = true;
        

        }
    }
}
