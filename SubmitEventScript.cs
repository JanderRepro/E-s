using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SubmitEventScript : MonoBehaviour
{

    public string path = "REDACTED";
    private string quietdonttellanybody = "REDACTED";
    public InputField namei;
    public Dropdown category;
    public InputField byear;
    public InputField bmonth;
    public InputField bday;
    public Dropdown btime;
    public InputField eyear;
    public InputField emonth;
    public InputField eday;
    public Dropdown etime;
    public InputField desci;
    public string username;
    public Text statustext;
    public GameObject statusbox;
    public UserScript uscript;
    public ActiveSetButtonScript spawnscript;
    public string lid;
    public GameObject sbox;

    public string begintime;
    public string endtime;

    public void OnEnable()
    {
        var currentyear = System.DateTime.UtcNow.ToString("yyyy");
        byear.text = System.DateTime.UtcNow.ToString("yyyy");
        eyear.text = System.DateTime.UtcNow.ToString("yyyy");
        bmonth.text = System.DateTime.UtcNow.ToString("MM");
        emonth.text = System.DateTime.UtcNow.ToString("MM");
    }

    // Use this for initialization
    public void OnPress()
    {
        username = uscript.username;
        lid = spawnscript.id;
        StartCoroutine(SubmitEvent());

    }

    // Update is called once per frame
    public IEnumerator SubmitEvent()
    {
        var form = new WWWForm();
        string tempUrl;


        sbox.transform.localScale = Vector3.one;
        statustext.text = "Checking date/time.";
        StartCoroutine(DonGoofed());
        //time processing begins
        var utcdif = System.DateTime.UtcNow - System.DateTime.Now;
        begintime = byear.text + "-" + bmonth.text + "-" + bday.text + " " + btime.value + ":00:00";
        var begindatetime = Convert.ToDateTime(begintime) + utcdif;

        endtime = eyear.text + "-" + emonth.text + "-" + eday.text + " " + etime.value + ":00:00";
        var enddatetime = Convert.ToDateTime(endtime) + utcdif;
        //time processing ends
        sbox.transform.localScale = Vector3.zero;

        sbox.transform.localScale = Vector3.one;
        if (username == "")
        {
            statustext.text = "You must be logged in.";
            yield break;
        }
        if (namei.text == "")
        {
            statustext.text = "You must input a name.";
            yield break;
        }
        if (byear.text == "" || bmonth.text == "" || bday.text == "" || eyear.text == "" || emonth.text == "" || eday.text == "")
        {
            statustext.text = "You must fill out all time fields.";
            yield break;
        }

        namei.text = namei.text.ToString().Replace("'", "’");
        desci.text = desci.text.ToString().Replace("'", "’");
        username = username.ToString().Replace("'", "’");

        namei.text = namei.text.ToString().Replace("^", "");
        desci.text = desci.text.ToString().Replace("^", "");
        username = username.ToString().Replace("^", "");

        namei.text = namei.text.ToString().Replace("*", "");
        desci.text = desci.text.ToString().Replace("*", "");
        username = username.ToString().Replace("*", "");

        namei.text = namei.text.ToString().Replace("\\", "");
        desci.text = desci.text.ToString().Replace("\\", "");
        username = username.ToString().Replace("\\", "");

        tempUrl = path + "?Username=" + WWW.EscapeURL(username) + "&Machine=" + WWW.EscapeURL(SystemInfo.deviceUniqueIdentifier) + "&ShindigName=" + WWW.EscapeURL(namei.text) + "&Drink=" + WWW.EscapeURL(category.options[category.value].text) + "&ShindigDescription=" + WWW.EscapeURL(desci.text) + "&StartTime=" + WWW.EscapeURL(begindatetime.ToString("yyyy-MM-dd HH:mm:ss")) + "&EndTime=" + WWW.EscapeURL(enddatetime.ToString("yyyy-MM-dd HH:mm:ss")) + "&LocationID=" + WWW.EscapeURL(lid);

        var w = new WWW(tempUrl);
        yield return w;
        sbox.transform.localScale = Vector3.one;
        statustext.text = "Connected!";
        if (w.error != null)
        {
            statustext.text = "Something went wrong.";
        }
        statustext.text = w.text;

        if (w.text == "Event submitted!")
        {
            namei.text = "";
            bday.text = "";
            eday.text = "";
            desci.text = "";
        }
    }

    public IEnumerator DonGoofed()
    {
        yield return new WaitForSeconds(1);

        if (statustext.text == "Checking date/time.")
        {
            sbox.transform.localScale = Vector3.one;
            statustext.text = "You must enter a valid date/time.";
        }
    }
}
