using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearBoxScript : MonoBehaviour
{
    public GameObject dabox;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void OnClick()
    {
        dabox.transform.localScale = Vector3.zero;
    }
}
