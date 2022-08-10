using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteppingPuzzleGame : MonoBehaviour
{
    public GameObject[] steppingStones;
  
    public static bool gamecomplete = false;
    GameObject player;
    int currentstone = 0;




    public void OnSteppingStone(GameObject go)
    {
        int whichstone;
        whichstone = WhichStone(go);

        Debug.Log("Stepped on stone" + whichstone);
        if (whichstone != currentstone)
        {

            foreach (GameObject stone in steppingStones)
                stone.GetComponent<Renderer>().material.color = Color.white;
            currentstone = 0;
            return;


        }

        go.GetComponent<Renderer>().material.color = Color.magenta;
        currentstone++;
        Debug.Log("current stone" + currentstone);
        if (currentstone == steppingStones.Length)
        {
            if (!gamecomplete)
            {
                gamecomplete = true;
               

            }
        }

    }
    int WhichStone(GameObject go)
    {

        for (int i = 0; i < steppingStones.Length; i++)
        {

            if (steppingStones[i] == go)
                return i;


        }

        return -1;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FpsController Variant");


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != player) return;
        

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != player) return;
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
