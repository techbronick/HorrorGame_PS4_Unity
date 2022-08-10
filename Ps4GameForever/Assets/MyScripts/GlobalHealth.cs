using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.PS4;

public class GlobalHealth : MonoBehaviour
{
    public static int currentHealth=20;
    public int internalHealth;
    public GameObject DisplayHealth;

    public int playerId;
    // Update is called once per frame
    void Update()
    {
        internalHealth = currentHealth;
        DisplayHealth.GetComponent<Text>().text = "" + currentHealth;
        if (currentHealth <= 0)
        {
            PS4Input.PadSetLightBar(playerId, 0, 0, 255);
            SceneManager.LoadScene("GameOver");
           
        }
    }
}
