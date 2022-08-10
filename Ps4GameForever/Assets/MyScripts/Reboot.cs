using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PS4;

public class Reboot : MonoBehaviour
{
    public GameObject FadeOut;
    public int playerId;

    public void Update()
    {

        RestartButton1();
    }
    public void RestartButton1()
    {
        if (Input.GetButtonDown("Restart"))
        {
            StartCoroutine(RestartGame1());
        }
    }

    IEnumerator RestartGame1()
    {
        PS4Input.PadSetLightBar(playerId, 0, 0, 255);
        Time.timeScale = 1;
        FadeOut.SetActive(true);
      
        yield return new WaitForSeconds(2);

        if (SceneManager.GetSceneByName("GameOver").isLoaded)
            SceneManager.UnloadSceneAsync("GameOver");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Level 2");

        GlobalAmmo.ammoCount = 0;
        GlobalHealth.currentHealth = 20;
    }


}
