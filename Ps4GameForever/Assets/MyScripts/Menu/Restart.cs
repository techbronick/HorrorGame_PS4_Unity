using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PS4;

public class Restart : MonoBehaviour
{
    public GameObject FadeOut;
    public AudioSource ButtonClick;
     public PauseTheGame ps;

    public int playerId;
    public void Update()
    {

        RestartButton();
    }
    public void RestartButton()
    {
        if (ps.gamePaused == true && Input.GetButtonDown("Restart"))
        {
            
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        Time.timeScale = 1;
        FadeOut.SetActive(true);
        ButtonClick.Play();
        yield return new WaitForSeconds(3);
         
        if(SceneManager.GetSceneByName("Level 2").isLoaded)
        SceneManager.UnloadSceneAsync("Level 2");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level 2");

        PS4Input.PadSetLightBar(playerId, 0, 0, 255);
        GlobalAmmo.ammoCount = 0;
        GlobalHealth.currentHealth = 20;
    }
}
