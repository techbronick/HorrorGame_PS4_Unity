using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PS4;

public class BreakVase : MonoBehaviour
{
    public GameObject fakeVase;
    public GameObject broakenVase;
    public GameObject sphere;
    public AudioSource BreakSound;
    public GameObject KeyObj;
    public GameObject KeyTrigger;
    public int playerId;
    void ZoombieDamage(int DamageAmount)
    {


        StartCoroutine(BrakeVase());
    }
    IEnumerator BrakeVase()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        
        BreakSound.PlayOnGamepad(playerId);
        KeyObj.SetActive(true);
        KeyTrigger.SetActive(true);
        fakeVase.SetActive(false);
        broakenVase.SetActive(true);

       
        yield return new WaitForSeconds(0.05f);
        sphere.SetActive(true);

        yield return new WaitForSeconds(0.05f);
        sphere.SetActive(false);

    }
}
