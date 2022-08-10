using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;
    public GameObject TDoor;
    public AudioSource Creepy;
    public GameObject Crosshair;



    void Update()
    {
        distance = PlayerCast.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (distance <= 2) 
        {
            Crosshair.SetActive(true);
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

                TDoor.GetComponent<Animation>().Play("FirstDoorOpenAnim");
                Creepy.Play();
            
            }
                
                    
                    
         }
            

       
    }
    private void OnMouseExit()
    {
        Crosshair.SetActive(false);
        DisplayAction.SetActive(false);
        TextAction.SetActive(false);
    }
}
