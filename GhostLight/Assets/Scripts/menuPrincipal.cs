using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuPrincipal : MonoBehaviour {

	public Text txtNoSave;

	public void newGameBtn(string newGameLevel)
	{	
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene(newGameLevel);
	}

	public void exitGameBtn()
	{
		Application.Quit();
	}

	public void continueBtn()
	{
		if (PlayerPrefs.HasKey("SaveData")) {
			SceneManager.LoadScene(PlayerPrefs.GetInt("SaveData"));
			print ("Game loaded!");
		} else {
			// no save !
			txtNoSave.text = "Aucune partie trouvée !";

		}
	}
}
