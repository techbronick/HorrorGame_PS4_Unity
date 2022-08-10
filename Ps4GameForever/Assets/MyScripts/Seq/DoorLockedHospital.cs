using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

using UnityEngine.PS4;

public class DoorLockedHospital : MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;


    public GameObject Crosshair;
    public AudioSource LockedDoorSound;
    public GameObject BunkerDoor;
    public AudioSource doorUnlocked;
    public AudioSource BunkerUnlockeSound;

    public int playerId;
   
    void Update()
    {
        distance = PlayerCast.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (distance <= 2)
        {
            Crosshair.SetActive(true);
            TextAction.GetComponent<Text>().text = "Open the door";
            DisplayAction.SetActive(true);
            TextAction.SetActive(true);
     
        }
        if (Input.GetButtonDown("Action"))

        {
            if (distance <= 2)
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
        if (SteppingPuzzleGame.gamecomplete==false)

        {
            LockedDoorSound.PlayOnGamepad(playerId);
            PS4Input.PadSetLightBar(playerId, 255, 0, 0);
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
          
           
        }
        else 
        
        {

            PS4Input.PadSetLightBar(playerId, 0, 255, 0);
            yield return new WaitForSeconds(1.5f);
            BunkerDoor.GetComponent<Animator>().Play("BunkerDoorAnim");
            BunkerUnlockeSound.PlayOnGamepad(playerId);
         
            yield return new WaitForSeconds(1.2f);
            this.GetComponent<BoxCollider>().enabled = false;
        }
       
       
    }
}
