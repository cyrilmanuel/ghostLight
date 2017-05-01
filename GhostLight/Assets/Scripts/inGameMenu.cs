using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inGameMenu : MonoBehaviour {

	GameObject PauseMenu;
	GameObject BaseLevel;
	AudioSource Audio;
	bool isMuted;
	bool isPaused;
	Texture fadeTexture;
	public Text muteText;
	public Text stateText;

	// Use this for initialization
	void Start () {
		isPaused = false;

		if (PlayerPrefs.HasKey("Mute")) {
			if (PlayerPrefs.GetInt ("Mute") != 0) {
				isMuted = true;
			} else {
				isMuted = false;
			}

		} else {
			isMuted = false;
		}



		PauseMenu = GameObject.Find("PauseMenu"); 
		BaseLevel = GameObject.Find("BaseLevel");
		GameObject audio = GameObject.Find("MusiqueManager"); 
		Audio = audio.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			PauseMenu.SetActive(true);
			Time.timeScale = 0;
		} else if (!isPaused){
			PauseMenu.SetActive(false);
			Time.timeScale = 1;
			stateText.text = "";
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			isPaused = !isPaused;
		}

		if (isMuted) {
			Audio.mute = true;
			muteText.text = "Activer la musique";
			//AudioListener.volume = 0;
		} else {
			//AudioListener.volume = 1;
			Audio.mute = false;
			muteText.text = "Désactiver la musique";
		}
	}



	public void muteBtn(){
		isMuted = !isMuted;
	}

	public void mainMenuBtn(string Level){
		SceneManager.LoadSceneAsync(0);
		//SceneManager.LoadScene(0);
	}

	public void saveBtn(){
		//PlayerPrefs.SetInt("currentSceneSave", SceneManager.LoadScene(SceneManager.GetActiveScene().name));
		PlayerPrefs.SetInt ("SaveData", SceneManager.GetActiveScene().buildIndex);
		int i = isMuted ? 1 : 0;
		PlayerPrefs.SetInt("Mute", i);
		PlayerPrefs.Save();
		stateText.text="Partie Sauvegarder !";
	}

	public void loadBtn(){
	//	SceneManager.LoadScene(PlayerPrefs.GetInt("currentSceneSave"));
		SceneManager.LoadScene(PlayerPrefs.GetInt("SaveData"));
	}

	public void resumeBtn(){
		isPaused=false;
	}
	public void exitGameBtn()
	{
		Application.Quit();
	}
}
