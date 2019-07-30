using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonScript : MonoBehaviour {

    public GameObject target;
    public Vector3 switchto;

	// Use this for initialization
	public void OnPress() {
        target.transform.localScale = switchto;
	}
}
