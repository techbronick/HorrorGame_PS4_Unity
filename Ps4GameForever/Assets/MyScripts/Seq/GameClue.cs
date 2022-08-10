using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClue: MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;
    public GameObject Crosshair;

    public GameObject zoombieObj;

    public GameObject PuzzleFade;
    public GameObject zoombieImg;
    public GameObject Text;



    void Update()
    {
        distance = PlayerCast.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (distance <= 2)
        {
            Crosshair.SetActive(true);
            TextAction.GetComponent<Text>().text = "Tip for killing a zoombie";
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
                StartCoroutine(startFade());

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
        zoombieImg.SetActive(true);
        Text.SetActive(true);
        yield return new WaitForSeconds(2.5f); ;
        PuzzleFade.SetActive(false);
        zoombieImg.SetActive(false);
        Text.SetActive(false);
        zoombieObj.SetActive(false);

    }
}
