using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickShotgunAmmo : MonoBehaviour
{
    public GameObject DisplayAmmoBox;
    public AudioSource ShotGunBulletsReload;
    void OnTriggerEnter(Collider other)
    {
        ShotGunBulletsReload.Play();
        DisplayAmmoBox.SetActive(true);
        GlobalAmmo.ShotgunAmmoCount += 5;
        gameObject.SetActive(false);
    }
}
