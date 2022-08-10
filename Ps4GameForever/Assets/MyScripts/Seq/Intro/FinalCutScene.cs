using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.PS4;

public class FinalCutScene : MonoBehaviour
{

    public GameObject player;
    public GameObject cutSceneCam;
    public GameObject Boss2;
    public GameObject PlayerSays;
    public GameObject BlackScreen;
    public AudioSource FinalSequence;
    public AudioSource ZoombieSound;

    public AudioSource Line1Ending;
    public AudioSource Line2Ending;

    public GameObject HealthPannel;
    public GameObject AmmoPannel;

    public int playerId;

    private void OnTriggerEnter(Collider other)
    {
        cutSceneCam.SetActive(true);
        player.SetActive(false);
        Boss2.SetActive(true);
        HealthPannel.SetActive(false);
        AmmoPannel.SetActive(false);
        StartCoroutine(BeginSeq());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BeginSeq()
    {
        PS4Input.PadSetLightBar(playerId, 0, 0, 255);
        FinalSequence.PlayOnGamepad(playerId);
        yield return new WaitForSeconds(4);
        PlayerSays.GetComponent<Text>().text = "What's this crazy place";
        Line1Ending.PlayOnGamepad(playerId);
        yield return new WaitForSeconds(1f);
        PlayerSays.GetComponent<Text>().text = "";


        yield return new WaitForSeconds(3);
        PlayerSays.GetComponent<Text>().text = "Hope its a final room.";
        Line2Ending.PlayOnGamepad(playerId);

        yield return new WaitForSeconds(1f);
        PlayerSays.GetComponent<Text>().text = "";


        yield return new WaitForSeconds(5.5f);
        ZoombieSound.PlayOnGamepad(playerId);
        BlackScreen.SetActive(true);

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("GameOver");
        SceneManager.UnloadSceneAsync("Level 2");


    }
}
