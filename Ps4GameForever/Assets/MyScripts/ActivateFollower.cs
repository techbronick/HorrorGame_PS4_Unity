using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFollower : MonoBehaviour
{


    public AudioSource ZoombieBreathing;
   void OnTriggerEnter(Collider other)
    {
      
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        MazeFolloweAi.startedfollow = true;
        ZoombieBreathing.Play();

    }
}
