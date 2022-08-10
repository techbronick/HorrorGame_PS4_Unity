using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDiactivatorTrig : MonoBehaviour
{
    public GameObject waitingPoint;
    public void OnTriggerEnter(Collider other)
    {

        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        waitingPoint.SetActive(true);
        MazeFolloweAi.returningHome2 = true;
    }
}
