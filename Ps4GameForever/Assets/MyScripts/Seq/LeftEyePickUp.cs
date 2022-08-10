using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PS4;

public class LeftEyePickUp: MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;
    public GameObject Crosshair;

    public GameObject leftEye;

    public GameObject PuzzleFade;
    public GameObject eyeImg;
    public GameObject Text;


    public GameObject fakeWall;
    public GameObject realWall;

    public AudioSource PickSound;

    public GameObject leftEyeInventory;

    public int playerId;
    void Update()
    {
        distance = PlayerCast.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (distance <= 5)
        {
            Crosshair.SetActive(true);
            TextAction.GetComponent<Text>().text = "Pick up the left part of the eye";
            DisplayAction.SetActive(true);
            TextAction.SetActive(true);

        }
        if (Input.GetButtonDown("Action"))

        {
            if (distance <= 5)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                DisplayAction.SetActive(false);
                TextAction.SetActive(false);
                Crosshair.SetActive(false);
                PickSound.PlayOnGamepad(playerId);
                Inventory.leftEye = true;
                StartCoroutine(startFade());
                if (Inventory.leftEye == true)
                {
                    leftEyeInventory.SetActive(true);
                
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
        fakeWall.SetActive(false);
        realWall.SetActive(true);
        Text.GetComponent<Text>().text = "YOU HAVE THE LEFT EYE PIECE";
        PuzzleFade.SetActive(true);
        eyeImg.SetActive(true);
        Text.SetActive(true);
        yield return new WaitForSeconds(2.5f); ;
        PuzzleFade.SetActive(false);
        eyeImg.SetActive(false);
        Text.SetActive(false);
        leftEye.SetActive(false);

    }
}
