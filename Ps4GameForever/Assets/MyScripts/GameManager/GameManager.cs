using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PS4;

public class GameManager : MonoBehaviour
{

    public int playerId;
     public AudioSource BackMus;
    // Start is called before the first frame update
    void Start()
    {
        BackMus.PlayOnGamepad(playerId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
