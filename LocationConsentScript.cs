using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationConsentScript : MonoBehaviour
{

    public GameObject thewindow;
    public UserScript uscript;

    public void OnPress()
    {
        uscript.locationconsent = true;
        if(this.gameObject.name == "YesButton"){
            PlayerPrefs.SetInt("LocationConsent", 1);
        }
        thewindow.SetActive(false);
    }
}
