using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsButtonScript : MonoBehaviour {

    public string name;
    public string streetaddress;
    public string xcoord;
    public string ycoord;
    public string url;

	// Use this for initialization
	public void OnPress() {
        name = name.Replace(" ", "+");
        streetaddress = streetaddress.Replace(" ", "+");
        url = "https://www.google.com/maps/place/" + streetaddress;
        Application.OpenURL(url);
	}
}
