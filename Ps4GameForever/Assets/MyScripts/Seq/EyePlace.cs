using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyePlace: MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;
    public GameObject Crosshair;

    public GameObject eyePieces;

    public GameObject realWall;

    public AudioSource SlidingDoor;

    public GameObject RighEyeInventory;
    public GameObject LeftEyeInventory;

    public int playerId;
    void Update()
    {
        distance = PlayerCast.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (Inventory.leftEye == false && Inventory.rightEye == false || Inventory.rightEye == true)
        {
            if (distance <= 2)
            {
                Crosshair.SetActive(true);
                TextAction.GetComponent<Text>().text = "Collect 2 eye Pieces and place them here ";
                TextAction.SetActive(true);
            }
        }
            if (Inventory.leftEye == true && Inventory.rightEye == true)
        {
            if (distance <= 2)
            {
                Crosshair.SetActive(true);
                TextAction.GetComponent<Text>().text = "PlaceEyePieces";
                DisplayAction.SetActive(true);
                TextAction.SetActive(true);

            }
            if (Input.GetButtonDown("Action"))

            {
                RighEyeInventory.SetActive(false);
                LeftEyeInventory.SetActive(false);
                if (distance <= 2)
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    DisplayAction.SetActive(false);
                    TextAction.SetActive(false);
                    Crosshair.SetActive(false);

                    eyePieces.SetActive(true);

                    realWall.GetComponent<Animator>().Play("realWallAnim");
                    SlidingDoor.PlayOnGamepad(playerId);
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

 
}
