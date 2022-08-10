using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PS4;

public class PickHealth : MonoBehaviour
{

    public AudioSource HealedSound;
    public int playerId;
    void OnTriggerEnter(Collider other)
    {

        GlobalHealth.currentHealth += 15;
        gameObject.SetActive(false);
        HealedSound.PlayOnGamepad(playerId);
    }
}
