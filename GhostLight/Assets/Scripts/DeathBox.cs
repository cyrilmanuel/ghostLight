using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour {
    private GameObject player;
    private GameObject levelbase;
    private BoxCollider box;
    public float height;
	// Use this for initialization
	void Start () {
		
	}

    void Awake() {
        player = GameObject.Find("Player");
        levelbase = GameObject.Find("LevelBottom");
        box = GetComponent<BoxCollider>() as BoxCollider;
        box.size = new Vector3(levelbase.transform.localScale.x, height, levelbase.transform.localScale.z);
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            player.GetComponent<PlayerController>().alive = false;
        }
    }
}
