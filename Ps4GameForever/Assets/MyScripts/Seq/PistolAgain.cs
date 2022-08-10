using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PS4;

public class PistolAgain : MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;
    public GameObject fakePistol;
    public GameObject realPistol;
    public GameObject realShotGun;
    public GameObject Crosshair;
    public GameObject FakeShotGun;
    public GameObject shotGunTrigger;
    public AudioSource PistolReload;
    public GameObject AmmoPannel;
    public GameObject ShotGunPannel;

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
            TextAction.GetComponent<Text>().text = "Pick up the gun";
            DisplayAction.SetActive(true);
            TextAction.SetActive(true);

        }
        if (Input.GetButtonDown("Action"))

        {
            if (distance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                shotGunTrigger.GetComponent<BoxCollider>().enabled = true;
                DisplayAction.SetActive(false);
                TextAction.SetActive(false);
              
                fakePistol.SetActive(false);
                realPistol.SetActive(true);
                realShotGun.SetActive(false);
                Crosshair.SetActive(false);
                FakeShotGun.SetActive(true);
                shotGunTrigger.SetActive(true);
                PistolReload.PlayOnGamepad(playerId);
                AmmoPannel.SetActive(true);
                ShotGunPannel.SetActive(false);
                Pistol.usingPistol = true;
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
