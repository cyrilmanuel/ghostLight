using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashOnLoad : MonoBehaviour {

	public Text start;
	public float diapoSeconds;
	public Canvas timer;
	public static bool isFinished;

	// Use this for initialization
	void Start () {
		isFinished = false;
		start.text = "Départ    dans   3";
		StartCoroutine(CinematicRoller());
		Time.timeScale = 0;
	}

	IEnumerator CinematicRoller()
	{
		for(int i = 3; i > 0; i--)
		{
			print (i.ToString ());
			start.text = "Départ    dans   "+ i.ToString();
			yield return new WaitForSecondsRealtime(diapoSeconds);

		}
		start.text = "L E T ' S      G O !!!";
		yield return new WaitForSecondsRealtime(diapoSeconds);
		Time.timeScale = 1;
		timer.gameObject.SetActive(false);
		isFinished = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
