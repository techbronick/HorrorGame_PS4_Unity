using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossActivator : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {

        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        FinalBossAI.isFollowingYou = true;


    }
}
