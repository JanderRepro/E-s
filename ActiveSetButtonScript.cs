using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSetButtonScript : MonoBehaviour {

    public GameObject target;
    public string id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void OnPress() {
        target.SetActive(true);
	}
}
