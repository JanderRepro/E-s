using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour {

    public GameObject safetynet;

	void OnEnable () {
        safetynet.SetActive(true);
	}
	
	void OnDisable () {
        safetynet.SetActive(false);
	}
}
