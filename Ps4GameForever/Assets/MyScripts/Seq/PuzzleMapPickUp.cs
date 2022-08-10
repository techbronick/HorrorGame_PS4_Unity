using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PS4;
public class PuzzleMapPickUp: MonoBehaviour
{
    public float distance;
    public GameObject DisplayAction;
    public GameObject TextAction;
    public GameObject Crosshair;

    public GameObject MapForPuzzle;

    public GameObject PuzzleFade;
    public GameObject MapImg;
    public GameObject MapText;

    public GameObject Arrow;

    public AudioSource PaperSound;

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
            TextAction.GetComponent<Text>().text = "Look at the note";
            DisplayAction.SetActive(true);
            TextAction.SetActive(true);

        }
        if (Input.GetButtonDown("Action"))

        {
            if (distance <= 2)
            {
                PaperSound.PlayOnGamepad(playerId);
                Arrow.SetActive(false);
               
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
        MapImg.SetActive(true);
        MapText.SetActive(true);
        yield return new WaitForSeconds(3.5f); ;
        PuzzleFade.SetActive(false);
        MapImg.SetActive(false);
        MapText.SetActive(false);
   

    }
}
