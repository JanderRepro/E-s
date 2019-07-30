using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedCreateButtonScript : MonoBehaviour
{
    public FindVenuesScript fvs;

    // Start is called before the first frame update
    void Start()
    {
        fvs = GameObject.Find("ListVenuesButton").GetComponent<FindVenuesScript>();
    }

    public void OnPress()
    {
        fvs.OnPress();
    }
}
