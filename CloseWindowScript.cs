using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindowScript : MonoBehaviour {

    public GameObject targetwindow;

	// Use this for initialization
	public void OnPress() {
        targetwindow.SetActive(false);
	}
}
