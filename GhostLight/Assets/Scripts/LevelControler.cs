using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControler : MonoBehaviour
{
    public Component spawn;
    public Component end;
    private GameObject deathBox;
    private Component player;
    private bool playersafe;
    private bool playerwon;
    private GameObject[] lights;
	// Use this for initialization
	void Awake () {
        player = FindObjectOfType<PlayerController>();
        playersafe = true;
        playerwon = false;
        deathBox = GameObject.Find("DeathBox");
        lights = GameObject.FindGameObjectsWithTag("Lights");
        player.transform.position = spawn.transform.position;
        player.transform.rotation = spawn.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject light in lights)
        {
            if (light.GetComponentInChildren<MeshCollider>().bounds.Contains(player.transform.position))
            {
                playersafe = true;
                if (light.name == "LightExit")
                {
                    playerwon = true;
                }
                break;
            }
            else {
                playersafe = false;
            }
        }
        if (deathBox.GetComponent<DeathBox>().isPlayerTouching() && !playersafe) {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
        }
        if (playerwon) {
            if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
            else
                SceneManager.LoadScene(0);
        }

	}

    public void SetPlayerWon(bool win)
    {
        print("We're here!");
        playerwon = win;
    }
    public void SetPlayerSafe(bool safe)
    {
        playersafe = safe;
    }
}
