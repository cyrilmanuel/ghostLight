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
                print("Player in " + light.name);
                playersafe = true;
                break;
            }
            else {
                print("Player not in " + light.name);
                playersafe = false;
            }
        }
        if (deathBox.GetComponent<DeathBox>().isPlayerTouching() && !playersafe) {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
        }
        if (playerwon) {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }

	}

    public void SetPlayerWon(bool win)
    {
        playerwon = win;
        print("Playerwon? " + playerwon);
    }
    public void SetPlayerSafe(bool safe)
    {
        playersafe = safe;
        print("Playersafe? " + playersafe);
    }
}
