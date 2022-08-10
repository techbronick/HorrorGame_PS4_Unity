using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingPuzzle : MonoBehaviour
{
    SteppingPuzzleGame spg;
    GameObject player;
    public AudioSource PressedPlatform;
    // Start is called before the first frame update
    void Start()
    {
        spg = GameObject.Find("SteppingPuzzleGame").GetComponent<SteppingPuzzleGame>();
        player = GameObject.Find("FpsController Variant");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != player) return;
        Debug.Log("stepped on stone" + this.transform.parent.gameObject.name);
        spg.OnSteppingStone(this.transform.parent.gameObject);
        PressedPlatform.Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
