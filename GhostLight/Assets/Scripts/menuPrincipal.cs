using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour {

	public void newGameBtn(string newGameLevel)
	{	
		SceneManager.LoadScene (newGameLevel);
	}

	public void exitGameBtn(string newGameLevel)
	{
		Application.Quit();
	}
}
