using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PS4;

public class DoorLocked : MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;


    public GameObject Crosshair;
    public AudioSource LockedDoorSound;
    public GameObject HingeDoor;
    public AudioSource doorUnlocked;
    public AudioSource Creek;

    public GameObject KeyImg;
    public GameObject TextCount;

    public int playerId;
    void Update()
    {
        distance = PlayerCast.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (distance <= 4)
        {
            Crosshair.SetActive(true);
            TextAction.GetComponent<Text>().text = "Open the door";
            DisplayAction.SetActive(true);
            TextAction.SetActive(true);

        }
        if (Input.GetButtonDown("Action"))

        {
            if (distance <= 4)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                DisplayAction.SetActive(false);
                TextAction.SetActive(false);
                Crosshair.SetActive(false);
                StartCoroutine(DoorReset());

            }



        }



    }
    private void OnMouseExit()
    {
        Crosshair.SetActive(false);
        DisplayAction.SetActive(false);
        TextAction.SetActive(false);
    }

    IEnumerator DoorReset()
    {
        if (Inventory.firstDoorKey == false)

        {
            LockedDoorSound.PlayOnGamepad(playerId);
            //lockedDoorSound();
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
            PS4Input.PadSetLightBar(playerId, 255, 0, 0);


        }
        else 
        
        {
            KeyImg.SetActive(false);
            TextCount.SetActive(false);
            doorUnlocked.Play();
            PS4Input.PadSetLightBar(playerId, 0, 255, 0);
            yield return new WaitForSeconds(2.5f);
            HingeDoor.GetComponent<Animator>().Play("DoorKeyOpenAnim");
            Creek.PlayOnGamepad(playerId);
         
            yield return new WaitForSeconds(1.2f);
            this.GetComponent<BoxCollider>().enabled = false;
        }
       
       
    }
   
    
}
