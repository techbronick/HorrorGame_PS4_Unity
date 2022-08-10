using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public GameObject FadeOut;
    public GameObject LoadText;
    public GameObject LoadIcon;
    public AudioSource ButtonClick;

    public GameObject loadButtn;
    public int loadInt;

    void Start()
    {
        loadInt = PlayerPrefs.GetInt("AutoSave");
        if (loadInt > 0)
        {
            loadButtn.SetActive(true);
        }
    }

    public void NewGameBut()
    {
        StartCoroutine(NewGameStart());
    
    }

    IEnumerator NewGameStart()
    {

        FadeOut.SetActive(true);
        ButtonClick.Play();
        yield return new WaitForSeconds(3);
        LoadText.SetActive(true);
        LoadIcon.SetActive(true);
        SceneManager.LoadScene(2);
    }

    public void LoadGameBtn()
    
    {
        StartCoroutine(LoadGame());
    
    }

    IEnumerator LoadGame()
    {

        FadeOut.SetActive(true);
        ButtonClick.Play();
        yield return new WaitForSeconds(3);
        LoadText.SetActive(true);
        LoadIcon.SetActive(true);
        SceneManager.LoadScene(loadInt);
    }
}
