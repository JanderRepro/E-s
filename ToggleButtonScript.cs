using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonScript : MonoBehaviour {

    public Toggle switcher;

	// Use this for initialization
	void Start () {
		
	}

    public void SwitchItUp()
    {
        ColorBlock cb = switcher.colors;

        if (switcher.isOn == true)
        {
            cb.normalColor = Color.green;
            cb.highlightedColor = Color.green;
        }
        else
        {
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
        }

        switcher.colors = cb;
    }
}
