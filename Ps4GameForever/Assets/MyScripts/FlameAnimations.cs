﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimations : MonoBehaviour
{
    public int lightMode;
    public GameObject FlameLight;

    void Update()
    {
        if (lightMode == 0)

        {
            StartCoroutine(AnimateLight());
        
        }
    }
    IEnumerator AnimateLight()
    {
        lightMode = Random.Range(1, 4);
        if (lightMode == 1)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim1");
        
        }
        if (lightMode == 2)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim2");

        }
        if (lightMode == 3)
        {
            FlameLight.GetComponent<Animation>().Play("TorchAnim3");

        }
        yield return new WaitForSeconds   (0.99f);
        lightMode = 0;
    }
}
