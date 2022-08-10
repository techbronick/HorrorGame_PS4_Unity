using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDeath : MonoBehaviour
{
    public int ZoombieHealth=20;
    public GameObject enemy;
    public int statusCheck;
    public AudioSource BackMus;

    public AudioSource ZoombieDead;
    public GameObject blood;
    public bool damaged ;

    void ZoombieDamage(int DamageAmount)
    {

     
        ZoombieHealth -= DamageAmount;
        blood.SetActive(true);
        damaged = true;

        StartCoroutine(Damage());

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (ZoombieHealth <= 0 && statusCheck == 0)
        {
            blood.SetActive(false);
            this.GetComponent<MazeFolloweAi>().enabled = false;
            this.GetComponent<MazeAttack>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            statusCheck = 2;
            ZoombieDead.Play();
            enemy.GetComponent<Animator>().Play("Dead");

            BackMus.Play();

        }
       
       
    }

    IEnumerator Damage()
    {
        if (damaged == true && ZoombieHealth > 0)
        {

            this.GetComponent<MazeFolloweAi>().enabled = false;
            this.GetComponent<MazeAttack>().enabled = false;

            enemy.GetComponent<Animator>().Play("Damaged");
            yield return new WaitForSeconds(1.2f);
            damaged = false;

        }

        if (damaged == false && ZoombieHealth > 0)
        {
            this.GetComponent<MazeFolloweAi>().enabled = true;
            this.GetComponent<MazeAttack>().enabled = true;

        }
       
        

    }
   
}
