using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PS4;

public class ShotGunPickUp : MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;
    public GameObject fakeShotGun;
    public GameObject RealShotGun;
    public GameObject realPistol;

    public GameObject Crosshair;
    public GameObject Arrow;

    public GameObject PistolTrigger;

    public GameObject fakePistol;

    public AudioSource ShotGunPick;
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
                PistolTrigger.GetComponent<BoxCollider>().enabled =true;
                DisplayAction.SetActive(false);
                TextAction.SetActive(false);
                fakeShotGun.SetActive(false);
                RealShotGun.SetActive(true);
                realPistol.SetActive(false);
                Crosshair.SetActive(false);
                fakePistol.SetActive(true);
                PistolTrigger.SetActive(true);
                AmmoPannel.SetActive(false);
                ShotGunPannel.SetActive(true);
                ShotGunPick.PlayOnGamepad(playerId);
                Pistol.usingPistol = false;
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
