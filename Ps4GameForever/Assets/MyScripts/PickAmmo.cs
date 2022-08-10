using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PS4;

public class PickAmmo : MonoBehaviour
{
    public GameObject DisplayAmmoBox;
    public AudioSource AmmoPickSound;
    public int playerId;
    void OnTriggerEnter(Collider other)
    {
        DisplayAmmoBox.SetActive(true);
        GlobalAmmo.ammoCount += 7;
        gameObject.SetActive(false);
        AmmoPickSound.PlayOnGamepad(playerId);
    }
}
