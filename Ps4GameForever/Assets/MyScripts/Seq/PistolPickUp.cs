using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolPickUp : MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;
    public GameObject fakePistol;
    public GameObject realPistol;

    public GameObject Crosshair;
    public GameObject Arrow;

    public GameObject JumpScareTrigger;
    public AudioSource PistolReload;


    void Update()
    {
        distance = PlayerCast.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (distance <= 2)
        {
            Crosshair.SetActive(true);
            TextAction.GetComponent<Text>().text = "Pick up the gun";
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

                fakePistol.SetActive(false);
                realPistol.SetActive(true);
                Crosshair.SetActive(false);
                Arrow.SetActive(false);
                JumpScareTrigger.SetActive(true);
                Pistol.usingPistol = true;
                PistolReload.Play();
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
