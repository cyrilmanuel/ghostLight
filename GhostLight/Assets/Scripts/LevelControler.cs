using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour
{
    public Component spawn;
    public Component end;
    private Component player;
	// Use this for initialization
	void Awake () {
        player = FindObjectOfType<PlayerController>();
        player.transform.position = spawn.transform.position;
        player.transform.rotation = spawn.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
