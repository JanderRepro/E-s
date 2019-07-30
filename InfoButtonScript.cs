using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButtonScript : MonoBehaviour {

    public GameObject popuppanel;
    public Text namebox;
    public Text supportbox;
    public Text descriptiontext;
    public WebsiteButtonScript webbut;
    public MapsButtonScript mapbut;
    public GameObject submiteventbut;

    public string targetname;
    public string lname;
    public string supportinfo;
    public string streetad;
    public string description;
    public string url;
    public string lid;

    public void OnPress()
    {
        popuppanel.transform.localScale = Vector3.one;
        namebox.text = targetname;
        supportbox.text = supportinfo;
        descriptiontext.text = description;
        webbut.url = url;
        mapbut.streetaddress = streetad;
        if (this.gameObject.name == "LocationName")
        {
            submiteventbut.transform.localScale = Vector3.one;
        }
        else submiteventbut.transform.localScale = Vector3.zero;
        submiteventbut.GetComponent<ActiveSetButtonScript>().id = lid;
    }

    public void Awake()
    {
        popuppanel = GameObject.Find("Popup");
        namebox = GameObject.Find("PopName").GetComponent<Text>();
        supportbox = GameObject.Find("SupportingText").GetComponent<Text>();
        descriptiontext = GameObject.Find("DescText").GetComponent<Text>();
        webbut = GameObject.Find("WebButton").GetComponent<WebsiteButtonScript>();
        mapbut = GameObject.Find("MapButton").GetComponent<MapsButtonScript>();
        submiteventbut = GameObject.Find("SubmitEventFromVenueButton");
    }
}
