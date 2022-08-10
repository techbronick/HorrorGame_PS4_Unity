using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TakeMeToMenu());
    }
    IEnumerator TakeMeToMenu()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(1);
    }
}
