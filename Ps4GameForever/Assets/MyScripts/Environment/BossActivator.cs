using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FinalBossAI.isFollowingYou = true;
    }
}
