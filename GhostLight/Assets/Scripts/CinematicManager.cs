using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour {

	public Canvas cinematicCanevas;

	public int cinematicSize;
	public int diapoSeconds;

	public int nextScene;

	// Use this for initialization
	void Start () {
		cinematicCanevas.gameObject.transform.FindChild("Cinematique_1").gameObject.SetActive(true);
		StartCoroutine(CinematicRoller());
	}

	IEnumerator CinematicRoller()
	{
		for(int i = 2; i <= cinematicSize; i++)
		{
			yield return new WaitForSeconds(diapoSeconds);
			cinematicCanevas.gameObject.transform.FindChild("Cinematique_" + (i-1)).gameObject.SetActive(false);
			cinematicCanevas.gameObject.transform.FindChild("Cinematique_" + i).gameObject.SetActive(true);
		}

		yield return new WaitForSeconds(diapoSeconds);
		SceneManager.LoadScene(nextScene);
	}

	// Update is called once per frame
	void Update () {

	}
}