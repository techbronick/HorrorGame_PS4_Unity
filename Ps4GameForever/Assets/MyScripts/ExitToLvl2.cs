using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitToLvl2 : MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;
    //public GameObject TDoor;
   // public AudioSource Creepy;
    public GameObject fadeOut;
    public GameObject Crosshair;



    void Update()
    {
        distance = PlayerCast.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (distance <= 2) 
        {
            TextAction.GetComponent<Text>().text = "Open the door";
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
                fadeOut.SetActive(true);
                StartCoroutine(fadeExit());

               // TDoor.GetComponent<Animation>().Play("FirstDoorOpenAnim");
               // Creepy.Play();
            
            }
                
                    
                    
         }
            

       
    }
    private void OnMouseExit()
    {
        Crosshair.SetActive(false);
        DisplayAction.SetActive(false);
        TextAction.SetActive(false);
    }

    IEnumerator fadeExit()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(5);
    }
}
