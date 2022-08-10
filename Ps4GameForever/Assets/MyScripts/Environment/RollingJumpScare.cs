using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PS4;
public class RollingJumpScare : MonoBehaviour
{
    public GameObject rollerObject;
    public GameObject Roll;

    public AudioSource SplashSound;

    public int playerId;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Roll.SetActive(true);
        StartCoroutine(DeactivateSphere());
    }

    IEnumerator DeactivateSphere()
    {
        yield return new WaitForSeconds(1);
        Roll.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        SplashSound.PlayOnGamepad(playerId);
    }
}
