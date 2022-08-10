using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PS4;
public class FlyingScare : MonoBehaviour
{
    public GameObject mugObject;
    public GameObject sphere;

    public AudioSource MugSound;

    public int playerId;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        sphere.SetActive(true);
        PS4Input.PadSetLightBar(playerId, 0, 0, 255);
        StartCoroutine(DeactivateSphere());
    }

    IEnumerator DeactivateSphere()
    {
        yield return new WaitForSeconds(1);
        PS4Input.PadSetVibration(playerId, 150, 150);
        sphere.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        MugSound.PlayOnGamepad(playerId);
    }
}
