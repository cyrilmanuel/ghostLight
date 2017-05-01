using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeCollider : MonoBehaviour {
    private bool playerin;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "Player") {
            playerin=true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            playerin = false;
        }
    }

    public bool isPlayerin() {
        return playerin;
    }
}
