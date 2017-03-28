using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControls : MonoBehaviour {
    public Toggle snap;
	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Update is called regardless of frame activity
    void FixedUpdate()
    {
        if (snap.isOn)
        {
            float x = Input.GetAxis("Vertical");
            float z = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Rotate");
            transform.Rotate(new Vector3(x, y, -z));
        }
        
    }
}
