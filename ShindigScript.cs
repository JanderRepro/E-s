using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ShindigScript : MonoBehaviour {

    public TimeSpan utcdifference;
    public RectTransform listlayout;
    public RectTransform myrect;
    public Text lnamebox;
    public Text snamebox;
    public Text distancebox;
    public Text timebox;
    public string address;
    public string website;
    public string locdesc;
    public string shindesc;
    public string stringx;
    public string stringy;
    public string lid;
    public Vector3 preferredscale;

    public InfoButtonScript locinfobutton;
    public InfoButtonScript shininfobutton;

    //Pop-up Panel stuff
    public GameObject popuppanel;
    public Text namebox;
    public Text supportbox;
    public WebsiteButtonScript webbut;

    public string Lname
    {
        set
        {
            lnamebox.text = value;
            locinfobutton.targetname = value;
            locinfobutton.lname = value;
            if (this.gameObject.tag == "shindiglist")
            {
                shininfobutton.lname = value;
            }
        }
    }

    public string Ldesc
    {
        set
        {
            locinfobutton.description = value;
        }
    }

    public string Sname
    {
        set
        {
            snamebox.text = value;
            shininfobutton.targetname = value;
        }
    }

    public string Website
    {
        set
        {
            locinfobutton.url = value;
            if (this.gameObject.tag == "shindiglist")
            {
                shininfobutton.url = value;
            }
        }
    }

    public string Sdesc
    {
        set
        {
            shininfobutton.description = value;
        }
    }

    public float Distance
    {
        set
        {
            distancebox.text = System.Math.Round(value,1) + " miles";
            if (System.Math.Round(value,1) == 1)
            {
                distancebox.text = "1 mile";
            }
        }
    }

    public string Address
    {
        set
        {
            locinfobutton.supportinfo = value;
            locinfobutton.streetad = value;
            if (this.gameObject.tag == "venuelist")
            {
                shininfobutton.streetad = value;
                snamebox.text = value;
            }
        }
    }

    public string Begin
    {
        set
        {
            var utcbegin = Convert.ToDateTime(value);
            utcbegin -= utcdifference;
            shininfobutton.supportinfo = "Begins " + utcbegin.ToString("ddd MMM dd, y h:mm tt");
            timebox.text = utcbegin.ToString("ddd MM/dd/y h:mm tt");

            if (utcbegin < System.DateTime.Now)
            {
                timebox.text = "Happening Now!";
            }
        }
    }

    public string End
    {
        set
        {
            var utcend = Convert.ToDateTime(value);
            utcend -= utcdifference;
            shininfobutton.supportinfo = shininfobutton.supportinfo + "\nEnds " + utcend.ToString("ddd h:mm tt");
        }
    }

    public string Lid
    {
        set
        {
            lid = value;
            locinfobutton.lid = value;
        }
    }

	// Use this for initialization
	void Awake () {
        listlayout = GameObject.Find("ListOfShindigs").GetComponent<RectTransform>();
        listlayout.sizeDelta = new Vector2(300, 70 * (listlayout.gameObject.transform.childCount+1) + 50);
        listlayout.localPosition += Vector3.down * 100f;
    }

    void Start()
    {
        myrect.localScale = preferredscale;
    }
}