using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PS4;

public class Pistol : MonoBehaviour
{
    public GameObject pistol;
    public GameObject Flash;
    public AudioSource shotSound;
    public float targetDistance;
    public int DamageAmount = 5;

    public bool isFiring = false;
    public static bool usingPistol = true;

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




        if (v.x > checkFlick.x && !alreadyFlicked && GlobalAmmo.ammoCount >= 1 && usingPistol == true)
        {

            if (isFiring == false)
            {
                GlobalAmmo.ammoCount -= 1;
                StartCoroutine(FiringPistol());
            }

        }

        else if (v.x <= checkFlick.x && alreadyFlicked)
        {

            alreadyFlicked = false;
        
        }

    }
    void Update()
    {
        
        
    }

    IEnumerator FiringPistol()
    {
        RaycastHit shot;
        isFiring = true;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            shot.transform.SendMessage("ZoombieDamage",DamageAmount,SendMessageOptions.DontRequireReceiver);
        }
        pistol.GetComponent<Animation>().Play("PistolAnim");
        Flash.SetActive(true);

        Flash.GetComponent<Animation>().Play("GunShotAnim");
        shotSound.PlayOnGamepad(playerId);
        yield return new WaitForSeconds(0.5f);
        isFiring = false;
    }
}
