using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalAmmo : MonoBehaviour
{
    public static int ammoCount;
    public GameObject DisplayAmmo;
    public int InternalAmmo;

    public static int ShotgunAmmoCount;
    public GameObject DisplayShotgunAmmo;
    public int InternalShotgunAmmo;

    void Update()
    {
        InternalAmmo = ammoCount;
        DisplayAmmo.GetComponent<Text>().text = ""+ammoCount;

        InternalShotgunAmmo = ShotgunAmmoCount;
        DisplayShotgunAmmo.GetComponent<Text>().text = "" + ShotgunAmmoCount;
    }
}
