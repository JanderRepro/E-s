using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseNetScript : MonoBehaviour {

    public GameObject marked;

    public void OnPress()
    {
        marked = GameObject.FindWithTag("window");
        marked.SetActive(false);
    }
}
