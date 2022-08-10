using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PS4;
public class RightEyePickUp: MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;
    public GameObject Crosshair;

    public GameObject rightEye;

    public GameObject PuzzleFade;
    public GameObject eyeImg;
    public GameObject Text;

    public GameObject rightEyeInventory;

    public AudioSource PickSound;

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
            TextAction.GetComponent<Text>().text = "Pick up the right part of the eye";
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
                Crosshair.SetActive(false);
                PickSound.PlayOnGamepad(playerId);
                Inventory.rightEye = true;
                StartCoroutine(startFade());
                if (Inventory.rightEye == true)
                {

                    rightEyeInventory.SetActive(true);
                }
            }



        }



    }
    private void OnMouseExit()
    {
        Crosshair.SetActive(false);
        DisplayAction.SetActive(false);
        TextAction.SetActive(false);
    }

    IEnumerator startFade()
    {
        PuzzleFade.SetActive(true);
        eyeImg.SetActive(true);
        Text.SetActive(true);
        yield return new WaitForSeconds(2.5f); ;
        PuzzleFade.SetActive(false);
        eyeImg.SetActive(false);
        Text.SetActive(false);
        rightEye.SetActive(false);

    }
}
