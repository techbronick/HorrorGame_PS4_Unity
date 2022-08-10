using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu: MonoBehaviour
{
    public GameObject FadeOut;
    public AudioSource ButtonClick;
    public void Menu()
    {
        StartCoroutine(BringMeToMenu());
    
    }

    IEnumerator BringMeToMenu()
    {
        Time.timeScale = 1;
        FadeOut.SetActive(true);
        ButtonClick.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
