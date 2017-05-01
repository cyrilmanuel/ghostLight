using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour {

	public void newGameBtn(string newGameLevel)
	{	
		SceneManager.LoadScene(newGameLevel);
	}

	public void exitGameBtn()
	{
		Application.Quit();
	}

	public void continueBtn()
	{
		if (PlayerPrefs.HasKey ("SaveData")) {

		} else {
			// no save !
			SceneManager.LoadScene(PlayerPrefs.GetInt("SaveData"));
			print ("Game loaded!");
		}
	}
}
