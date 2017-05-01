using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;

public class inGameMenu : MonoBehaviour {

	GameObject PauseMenu;
	bool isMuted;
	bool isPaused;

	// Use this for initialization
	void Start () {
		isPaused = false;
		isMuted = false;
		PauseMenu = GameObject.Find ("PauseMenu"); 
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			PauseMenu.SetActive(true);
			Time.timeScale = 0;
		} else if (!isPaused){
			PauseMenu.SetActive(false);
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {

			print("caca");
			isPaused = !isPaused;
		}

		if (isMuted) {
			AudioListener.volume = 0;
		} else {
			AudioListener.volume = 1;
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
	}

	public void loadBtn(){
	//	SceneManager.LoadScene(PlayerPrefs.GetInt("currentSceneSave"));
	}

	public void resumeBtn(){
		isPaused=false;
	}
	public void exitGameBtn()
	{
		Application.Quit();
	}
}
