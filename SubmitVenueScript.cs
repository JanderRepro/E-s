using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitVenueScript : MonoBehaviour {

    public string path = "http://box5278.temp.domains/~graviui5/addvenue.php";
    private string quietdonttellanybody = "eT0lxSaSImMQG9an7f3b";
    public InputField namei;
    public InputField addressi;
    public InputField websitei;
    public InputField desci;
    public InputField lati;
    public InputField longi;
    public Dropdown latd;
    public Dropdown longd;
    public string username;
    public Text statustext;
    public UserScript uscript;
    public GameObject sbox;


    // Use this for initialization
    public void OnPress() {
        username = uscript.username;
        if (lati.text == "" || longi.text == "")
        {
            sbox.transform.localScale = Vector3.one;
            statustext.text = "Latitude and Longitude are required.";
        }
        StartCoroutine(SubmitVenue());
    }

    // Update is called once per frame
    public IEnumerator SubmitVenue() {
        var form = new WWWForm();
        string tempUrl;
        
        float latreal = float.Parse(lati.text);
        float longreal = float.Parse(longi.text);
        if (latd.value == 0)
        {
            latreal = Mathf.Abs(latreal);
        }
        else latreal = -Mathf.Abs(latreal);

        if (longd.value == 0)
        {
            longreal = -Mathf.Abs(longreal);
        }
        else longreal = Mathf.Abs(longreal);

        string latfinal = latreal.ToString();
        string longfinal = longreal.ToString();



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
        if (addressi.text == "")
        {
            statustext.text = "You must input an address.";
            yield break;
        }
        if (websitei.ToString().Contains("*") || websitei.ToString().Contains("^"))
        {
            statustext.text = "Website field cannot contain * or ^.";
            yield break;
        }

        //Sanitize input
        namei.text = namei.text.ToString().Replace("'", "’");
        addressi.text = addressi.text.ToString().Replace("'", "’");
        desci.text = desci.text.ToString().Replace("'", "’");
        websitei.text = websitei.text.ToString().Replace("'", "’");
        username = username.ToString().Replace("'", "’");

        namei.text = namei.text.ToString().Replace("^", "");
        addressi.text = addressi.text.ToString().Replace("^", "");
        desci.text = desci.text.ToString().Replace("^", "");
        websitei.text = websitei.text.ToString().Replace("^", "");
        username = username.ToString().Replace("^", "");

        namei.text = namei.text.ToString().Replace("*", "");
        addressi.text = addressi.text.ToString().Replace("*", "");
        desci.text = desci.text.ToString().Replace("*", "");
        websitei.text = websitei.text.ToString().Replace("*", "");
        username = username.ToString().Replace("*", "");

        namei.text = namei.text.ToString().Replace("\\", "");
        addressi.text = addressi.text.ToString().Replace("\\", "");
        desci.text = desci.text.ToString().Replace("\\", "");
        websitei.text = websitei.text.ToString().Replace("\\", "");
        username = username.ToString().Replace("\\", "");
        //Sanitize end

        tempUrl = path + "?Username=" + WWW.EscapeURL(username) + "&Machine=" + WWW.EscapeURL(SystemInfo.deviceUniqueIdentifier) + "&LocationName=" + WWW.EscapeURL(namei.text) + "&Address=" + WWW.EscapeURL(addressi.text) + "&Description=" + WWW.EscapeURL(desci.text) + "&Website=" + WWW.EscapeURL(websitei.text) + "&Latitude=" + WWW.EscapeURL(latfinal) + "&Longitude=" + WWW.EscapeURL(longfinal);

        var w = new WWW(tempUrl);
        yield return w;
        sbox.transform.localScale = Vector3.one;
        statustext.text = "Connected!";
        if (w.error != null)
        {
            statustext.text = "Something went wrong.";
        }
        statustext.text = w.text;

        if (w.text == "Venue submitted!")
        {
            namei.text = "";
            addressi.text = "";
            websitei.text = "";
            desci.text = "";
            lati.text = "";
            longi.text = "";
        }
    }
}
