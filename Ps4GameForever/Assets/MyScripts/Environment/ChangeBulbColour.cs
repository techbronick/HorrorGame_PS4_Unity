using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBulbColour : MonoBehaviour
{


    public GameObject redLight;
    public GameObject GreenLight;
    public GameObject LightBulb;

    public void onColorChange(GameObject LightBulb)
    {
        if (SteppingPuzzleGame.gamecomplete == true)
        {
            LightBulb.GetComponent<Renderer>().material.color = Color.green;
            GreenLight.SetActive(true);
            redLight.SetActive(false);

        }
    
    }
    public void Update()
    {
        onColorChange(LightBulb);
    }
}
