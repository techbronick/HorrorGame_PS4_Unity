﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("AutoSave", 3);
    }

   
}
