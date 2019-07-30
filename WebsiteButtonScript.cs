using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebsiteButtonScript : MonoBehaviour {

    public string url;
	
	// Update is called once per frame
	public void OnPress () {
        if (url != "")
        {
            Application.OpenURL(url);
        }
	}
}
