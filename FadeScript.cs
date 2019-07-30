using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {

    public Text thistext;
    public Time stamp;
    public Color clearwhite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public IEnumerator GetToFadin()
    {
        yield return new WaitForSeconds(10);
        float alpha = thistext.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 1.0f)
        {
            thistext.color = new Color(1, 1, 1, Mathf.Lerp(alpha, 0f, t));
            yield return null;
        }
    }
}
