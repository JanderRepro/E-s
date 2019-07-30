using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindVenuesScript : MonoBehaviour
{
    public Text notetext;
    public Button backbut;
    private string quietdonttellanybody = "REDACTED";
    public string path = "REDACTED";
    public Vector2 urhere;
    public bool isrunning = false;
    public float herex;
    public float herey;
    public string mytext;
    public Vector2 coordinates;
    public GameObject locationobject;
    public GameObject listable;
    public ShindigScript listscript;
    public GameObject listselect;
    public RefreshButtonScript refbutscript;
    public FadeScript fader;
    public GameObject headtext;
    public GameObject bottombut;
    public GameObject submitvenuewindow;
    public GameObject submitshindigwindow;
    public UserScript uscript;
    public GameObject locationconsentwindow;

    //Pop-up Panel stuff
    public GameObject popuppanel;
    public Text namebox;
    public Text supportbox;
    public Text distinput;
    public WebsiteButtonScript webbut;

    public GameObject splashpanel;

    /*public void Awake()
    {
        refbutscript = GameObject.Find("RefreshButton").GetComponent<RefreshButtonScript>();
        drinkselect = gameObject.name;
    }*/

    public void OnPress()
    {
        notetext.color = Color.white;
        notetext.text = "Initializing...";
        StopAllCoroutines();
        notetext.color = Color.white;
        if (isrunning == true)
        {
            backbut.interactable = true;
            notetext.text = "Canceled";
            isrunning = false;
            return;
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            Input.location.Start();
        }

        if (uscript.locationconsent == false && Application.platform == RuntimePlatform.IPhonePlayer)
        {
            locationconsentwindow.SetActive(true);
            isrunning = false;
            return;
        }
        else StartCoroutine(LocationMethod());
    }

    IEnumerator LocationMethod()
    {
        Input.location.Start();
        yield return new WaitForSeconds(3);
        if (!Input.location.isEnabledByUser)
        {
            notetext.text = "Location disabled!";
            yield break;
        }
        splashpanel.transform.localScale = Vector3.zero;
        isrunning = true;
        backbut.interactable = false;
        //Input.location.Start();

        notetext.color = Color.white;
        notetext.text = "Finding Location...";

        int maxwait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxwait > 0)
        {
            yield return new WaitForSeconds(1);
            notetext.text = "Finding Location: " + maxwait;
            maxwait--;
        }

        if (maxwait < 1)
        {
            notetext.text = "Timed out.";
            notetext.color = Color.red;
            isrunning = false;
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            notetext.text = "Unable to determine location.";
            notetext.color = Color.red;
            isrunning = false;
            yield break;
        }
        else
        {
            //notetext.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
            notetext.text = "Location Found!";
            urhere = new Vector2((float)Input.location.lastData.latitude, (float)Input.location.lastData.longitude);
            herex = Input.location.lastData.latitude;
            herey = Input.location.lastData.longitude;

            notetext.color = Color.green;
            StartCoroutine(CallDB());
        }

        Input.location.Stop();
    }

    IEnumerator CallDB()
    {
        foreach (Transform child in listable.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        GameObject header = Instantiate(headtext);
        header.transform.parent = listable.transform;
        header.transform.localScale = Vector3.one;
        header.SetActive(false);
        notetext.color = Color.white;
        notetext.text = "Connecting to database...";

        WWW www = new WWW(path);
        yield return www;
        notetext.color = Color.white;
        notetext.text = "Searching database...";
        if (www.error != null)//error is found
        {
            notetext.color = Color.red;
            notetext.text = www.text;
        }

        /*if (gameObject.tag != "refbut")
        {
            refbutscript.drinkselect = gameObject.name;
        }*/

        //Here's where the magic happens
        var radius = 50f;
        if (distinput.text != "")
        {
            radius = float.Parse(distinput.text);
        }

        var matchfound = false;
        string[] temp = www.text.Split("^".ToCharArray());
        Debug.Log("Temp is " + temp.Length);
        for (var i=0; i < temp.Length-1; i+=1)
        {
            string[] othert = temp[i].Split("*".ToCharArray());
            
            var dist = measure(float.Parse(othert[1]), float.Parse(othert[2]), herex, herey);
            if (dist <= radius)
            {
                header.SetActive(true);
                //now create a thing if the distance checks out
                matchfound = true;
                GameObject newdig = Instantiate(locationobject);
                newdig.transform.parent = listable.transform;
                var digscript = newdig.GetComponent<ShindigScript>();

                digscript.popuppanel = popuppanel;

                digscript.Lname = othert[0];
                digscript.Distance = measure(float.Parse(othert[1]), float.Parse(othert[2]), herex, herey);
                digscript.Address = othert[4];
                digscript.Website = othert[5];
                digscript.Ldesc = othert[3];
                digscript.Lid = othert[6];
            }
            yield return null;
        }
        notetext.color = Color.white;
        notetext.text = "List completed!";
        StartCoroutine(fader.GetToFadin());
        GameObject lastpart = Instantiate(bottombut);
        lastpart.transform.parent = listable.transform;
        lastpart.transform.localScale = Vector3.one;

        submitvenuewindow.SetActive(true);
        var butscript = lastpart.GetComponent<ActiveSetButtonScript>().target = submitvenuewindow;

        submitvenuewindow.SetActive(false);

        if (matchfound == false)
        {
            notetext.color = Color.red;
            notetext.text = "No results found.";
        }
        backbut.interactable = true;
        isrunning = false;
    }

    public float d2r(float degree)
    {
        return degree * Mathf.PI / 180;
    }

    public float measure(float lat1, float lon1, float lat2, float lon2)
    {
        var earthradiusMi = 3959f;

        var dLat = d2r(lat2 - lat1);
        var dLon = d2r(lon2 - lon1);

        lat1 = d2r(lat1);
        lat2 = d2r(lat2);

        var a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) + Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2) * Mathf.Cos(lat1) * Mathf.Cos(lat2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return earthradiusMi * c;
    }

}
