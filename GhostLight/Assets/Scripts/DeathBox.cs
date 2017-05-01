using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour {
    private GameObject levelbase;
    private BoxCollider box;
    public float height;
    private bool playertouching;
	// Use this for initialization
	void Start () {
		
	}

    void Awake() {
        levelbase = GameObject.Find("LevelBottom");
        box = GetComponent<BoxCollider>() as BoxCollider;
        playertouching = true;
        box.size = new Vector3(levelbase.transform.localScale.x, height, levelbase.transform.localScale.z);
    }

	// Update is called once per frame
	void Update () {

    }

    void OnCollisionExit(Collision col)
    {
        print(col.gameObject.name);
        if (col.gameObject.name == "Player")
        {
            playertouching = false;
        }
    }

    public bool isPlayerTouching() {
        return playertouching;
    }
}
