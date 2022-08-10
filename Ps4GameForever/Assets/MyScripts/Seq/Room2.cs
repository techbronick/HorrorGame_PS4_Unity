using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2 : MonoBehaviour
{
    public AudioSource DoorBang;
    public AudioSource JumpScare;
    public GameObject zoombie;
    public GameObject Door;
    public AudioSource BackMus;

     void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        Door.GetComponent<Animation>().Play("secondDoorAnim");
        DoorBang.Play();
        zoombie.SetActive(true);
        StartCoroutine(PlayJumpScareMusic());
    }

    IEnumerator PlayJumpScareMusic()
    {

        yield return new WaitForSeconds(0.3f);
        BackMus.Stop();
        JumpScare.Play();
    }
}
