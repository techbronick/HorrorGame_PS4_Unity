using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSeq : MonoBehaviour
{
    public GameObject PlayerSays;
    public GameObject DateDisplay;
    public GameObject PlaceDisplay;

    public AudioSource thudSound;
    public GameObject BlackScreen;

    public AudioSource startL1;

    public AudioSource startL2;

    public AudioSource startL3;

    public AudioSource startL4;

    public AudioSource startL5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginSeq());
    }

    IEnumerator BeginSeq()
    {
        yield return new WaitForSeconds(3);
        PlaceDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        DateDisplay.SetActive(true);
        yield return new WaitForSeconds(4);

        PlaceDisplay.SetActive(false);
        DateDisplay.SetActive(false);

        startL1.Play();
        yield return new WaitForSeconds(4);
        PlayerSays.GetComponent<Text>().text = "Night of November can't remember the exact day,changed me forever.";
     

        yield return new WaitForSeconds(4.5f);
        PlayerSays.GetComponent<Text>().text = "";


        startL2.Play();
        yield return new WaitForSeconds(3);
        PlayerSays.GetComponent<Text>().text = "As a detective I went to investigate a murderer in the woods.";


        yield return new WaitForSeconds(5);
        PlayerSays.GetComponent<Text>().text = "";

        startL3.Play();
        yield return new WaitForSeconds(4);
        PlayerSays.GetComponent<Text>().text = "3 nights before I heard weird noises coming from the shed ";

        yield return new WaitForSeconds(5);
        PlayerSays.GetComponent<Text>().text = "";


        startL4.Play();
        yield return new WaitForSeconds(5);
        PlayerSays.GetComponent<Text>().text = "Villagers warned me about that place,telling that it is haunted";

        yield return new WaitForSeconds(6);
        PlayerSays.GetComponent<Text>().text = "";

        startL5.Play();
        yield return new WaitForSeconds(4);
        PlayerSays.GetComponent<Text>().text = "I din't believe in fairytails,until that day ";

        yield return new WaitForSeconds(5);
        PlayerSays.GetComponent<Text>().text = "";


        yield return new WaitForSeconds(17);
        BlackScreen.SetActive(true);
        thudSound.Play();

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);

    }

}
