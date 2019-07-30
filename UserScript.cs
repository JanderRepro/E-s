using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserScript : MonoBehaviour {

    public string path = "REDACTED";
    public string username;
    public Text userui;
    public bool locationconsent = false;

    public string Username
    {
        set
        {
            username = value;
            userui.text = "User: <b><color=yellow>" + value + "</color></b>";
        }
    }

    // Use this for initialization
    void Awake () {
        if (PlayerPrefs.GetInt("RememberMe") == 1)
        {
            var form = new WWWForm();
            string tempURL;

            tempURL = path + "?Username=" + WWW.EscapeURL(PlayerPrefs.GetString("SavedName")) + "&Password=" + WWW.EscapeURL(PlayerPrefs.GetString("SavedPW")) + "&Action=login";
            var w = new WWW(tempURL);
            if (w.ToString() == "Login successful!")
            {
                Username = PlayerPrefs.GetString("SavedName");
            }
            else
            {
                userui.text = "There was an error logging you in.";
            }
        }
        if (PlayerPrefs.GetInt("LocationConsent") == 1)
        {
            locationconsent = true;
        }
    }
}
