using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool firstDoorKey = false;
    public bool internalBoolKey;
    public static bool rightEye = false;
    public static bool leftEye = false;


    // Update is called once per frame
    void Update()
    {
        internalBoolKey=firstDoorKey;
    }
}
