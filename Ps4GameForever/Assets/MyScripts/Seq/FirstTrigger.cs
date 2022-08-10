using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject PlayerSays;
    public GameObject marker;
  
    public AudioSource WeaponSay;
      void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        player.GetComponent<CharController_Motor>().enabled = false;
        StartCoroutine(ScenePlayer());

       
    }
    IEnumerator ScenePlayer()
    {
        PlayerSays.GetComponent<Text>().text = "Looks like a weapon on the table ";
        WeaponSay.Play();
        yield return new WaitForSeconds(2.5f);
        PlayerSays.GetComponent<Text>().text = "";
        player.GetComponent<CharController_Motor>().enabled = true;

        marker.SetActive(true);
    }
}
