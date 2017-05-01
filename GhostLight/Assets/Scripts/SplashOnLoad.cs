using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashOnLoad : MonoBehaviour {

	public Text start;
	public int diapoSeconds;

	// Use this for initialization
	void Start () {
			start.text = "DEPART DANS 3";
		StartCoroutine(CinematicRoller());
	}

	IEnumerator CinematicRoller()
	{
		for(int i = 3; i >= 0; i--)
		{
			yield return new WaitForSeconds(diapoSeconds);
			start.text = "DEPART DANS "+ i;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
