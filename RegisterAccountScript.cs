using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterAccountScript : MonoBehaviour {

    public string path = "REDACTED";
    private string quietdonttellanybody = "REDACTED";
    public string action;
    public InputField useri;
    public InputField emaili;
    public InputField passi;
    public InputField passci;
    public InputField cityi;
    public InputField statei;
    public Text statustext;
    public Button thebutt;
    public UserScript uscript;
    public Toggle remembery;
    public GameObject sbox;

    public void OnEnable()
    {
        if (PlayerPrefs.GetInt("RememberMe") == 0)
        {
            remembery.isOn = false;
        }
    }

    public void OnPress()
    {
        StartCoroutine(LogReg());
    }

    public IEnumerator LogReg() {
        sbox.transform.localScale = Vector3.one;
        statustext.text = "Connecting...";
        var form = new WWWForm();
        string tempURL;
        if (action == "login")
        {
            if (useri.text == "" || passi.text == "")
            {
                sbox.transform.localScale = Vector3.one;
                statustext.text = "Fields incomplete!";
                yield break;
            }

            useri.text = useri.text.ToString().Replace("'", "’");
            passi.text = passi.text.ToString().Replace("'", "’");

            useri.text = useri.text.ToString().Replace("^", "");
            passi.text = passi.text.ToString().Replace("^", "");

            useri.text = useri.text.ToString().Replace("*", "");
            passi.text = passi.text.ToString().Replace("*", "");

            useri.text = useri.text.ToString().Replace("\\", "");
            passi.text = passi.text.ToString().Replace("\\", "");

            tempURL = path + "?Username=" + WWW.EscapeURL(useri.text) + "&Password=" + WWW.EscapeURL(passi.text) + "&Action=" + action;
            useri.text = useri.text.ToString().Replace("’", "'");
            Debug.Log(tempURL);
        }
        else
        {
            sbox.transform.localScale = Vector3.one;
            if (useri.text.ToString().Length < 3)
            {
                statustext.text = "Please input a name at least 3 characters long.";
                yield break;
            }
            if (passi.text.ToString().Length < 8)
            {
                statustext.text = "Please input a password at least 8 characters long.";
                yield break;
            }
            if (passi.text == "password" || passi.text == "sunshine" || passi.text == "qwerty")
            {
                statustext.text = "Please input a less obvious password.";
                yield break;
            }
            double blurgh; //It's dumb, but this HAS to be here because reasons
            if (double.TryParse(passi.text.ToString(), out blurgh)) //password is just numbers
            {
                statustext.text = "Try throwing in a letter or special character.";
                yield break;
            }
            if (passi.text != passci.text)
            {
                statustext.text = "Passwords do not match.";
                yield break;
            }
            Debug.Log(statustext.text);

            useri.text = useri.text.ToString().Replace("'", "’");
            passi.text = passi.text.ToString().Replace("'", "’");
            emaili.text = emaili.text.ToString().Replace("'", "’");
            cityi.text = cityi.text.ToString().Replace("'", "’");
            statei.text = statei.text.ToString().Replace("'", "’");

            useri.text = useri.text.ToString().Replace("^", "");
            passi.text = passi.text.ToString().Replace("^", "");
            emaili.text = emaili.text.ToString().Replace("^", "");
            cityi.text = cityi.text.ToString().Replace("^", "");
            statei.text = statei.text.ToString().Replace("^", "");

            useri.text = useri.text.ToString().Replace("*", "");
            passi.text = passi.text.ToString().Replace("*", "");
            emaili.text = emaili.text.ToString().Replace("*", "");
            cityi.text = cityi.text.ToString().Replace("*", "");
            statei.text = statei.text.ToString().Replace("*", "");

            useri.text = useri.text.ToString().Replace("\\", "");
            passi.text = passi.text.ToString().Replace("\\", "");
            emaili.text = emaili.text.ToString().Replace("\\", "");
            cityi.text = cityi.text.ToString().Replace("\\", "");
            statei.text = statei.text.ToString().Replace("\\", "");

            tempURL = path + "?Username=" + WWW.EscapeURL(useri.text.ToString().Trim()) + "&Password=" + WWW.EscapeURL(passi.text) + "&Email=" + WWW.EscapeURL(emaili.text) + "&City=" + WWW.EscapeURL(cityi.text.ToString().Trim()) + "&Province=" + WWW.EscapeURL(statei.text.ToString().Trim()) + "&Prefdevice=" + WWW.EscapeURL(SystemInfo.deviceUniqueIdentifier) + "&Action=" + action;
            useri.text = useri.text.ToString().Replace("’", "'");
        }
        
        var w = new WWW(tempURL);
        yield return w;
        sbox.transform.localScale = Vector3.one;
        statustext.text = "Connected!";
        if (w.error != null)
        {
            statustext.text = "Something went wrong.";
        }
        statustext.text = w.text;
        
        if (statustext.text == "Login successful!" || statustext.text == "Account registered. Welcome to E's!")
        {
            uscript.Username = useri.text; //You are now logged in
            if (remembery.isOn == true)
            {
                PlayerPrefs.SetInt("RememberMe", 1);
            }
            else PlayerPrefs.SetInt("RememberMe", 0);
        }
    }
}
