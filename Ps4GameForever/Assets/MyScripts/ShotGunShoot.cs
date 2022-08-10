using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PS4;

public class ShotGunShoot : MonoBehaviour
{
    public GameObject ShotGun;
    public GameObject Flash;
    public GameObject Flash2;
    public float targetDistance;
    public int DamageAmount = 15;
    public AudioSource shootSound;
    public bool isFiring = false;

    public int playerId;



    bool checkFlick;
    bool checkTilt;
    bool alreadyFlicked;



    void Start()
    {
        PS4Input.PadIsConnected(playerId);

    }



    void FixedUpdate()
    {

        Vector4 v = PS4Input.PadGetLastOrientation(playerId);
        Vector4 checkFlick = new Vector4(0.3f, 0, 0, 0);
        Vector4 checkTilt = new Vector4(0, 0, 0.2f, 0);

        if (v.x > checkFlick.x && !alreadyFlicked && GlobalAmmo.ShotgunAmmoCount >= 1 && Pistol.usingPistol == false)
        {
            if (isFiring == false)
            {
                GlobalAmmo.ShotgunAmmoCount -= 1;
                StartCoroutine(FiringShotGun());
            }

        }

        else if (v.x <= checkFlick.x && alreadyFlicked)
        {

            alreadyFlicked = false;

        }

    }



   

    IEnumerator FiringShotGun()
    {
        RaycastHit shot;
        isFiring = true;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            shot.transform.SendMessage("ZoombieDamage",DamageAmount,SendMessageOptions.DontRequireReceiver);
        }
        shootSound.PlayOnGamepad(playerId);
        ShotGun.GetComponent<Animation>().Play("ShotGunAnim");
        Flash.SetActive(true);
        Flash.GetComponent<Animation>().Play("GunShotAnim");
        Flash2.SetActive(true);
        Flash2.GetComponent<Animation>().Play("GunShotAnim");

        yield return new WaitForSeconds(0.5f);
        isFiring = false;
    }
}
