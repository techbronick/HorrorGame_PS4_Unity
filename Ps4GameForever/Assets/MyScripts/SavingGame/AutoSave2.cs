using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave2 : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        Pistol.usingPistol = true;
        PlayerPrefs.SetInt("AutoSave", 5);
        Inventory.firstDoorKey = false;
        Inventory.rightEye = false;
        Inventory.leftEye = false;
    }

   
}
