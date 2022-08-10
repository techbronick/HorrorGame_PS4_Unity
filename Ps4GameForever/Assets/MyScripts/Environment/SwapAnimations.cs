using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapAnimations : MonoBehaviour
{
    public GameObject waitingPoint;
    public GameObject finalDiactivator;
    private void OnTriggerEnter(Collider other)
    {

        waitingPoint.SetActive(false);
    MazeFolloweAi.returningHome2 = false;

        finalDiactivator.SetActive(true);

    }
}
