using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{

    public GameObject player;
    public GameObject Fade;
    public GameObject PlayerSays;
    public AudioSource Line1;
    public AudioSource Line2;
 
    // Start is called before the first frame update
    void Start()
    {

        player.GetComponent<CharController_Motor>().enabled = false;
        StartCoroutine(ScenePlayer());
        
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        Fade.SetActive(false);
        PlayerSays.GetComponent<Text>().text = " ...where am I? ";
        Line1.Play();
        yield return new WaitForSeconds(2);
        PlayerSays.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        PlayerSays.GetComponent<Text>().text = "I have to get out of here ";
        Line2.Play();
        yield return new WaitForSeconds(2);
        PlayerSays.GetComponent<Text>().text = "";
        player.GetComponent<CharController_Motor>().enabled = true;



    }
 
}
