using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControls : MonoBehaviour {
    private Rigidbody level;
	// Use this for initialization
	void Start () {
        level = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Update is called regardless of frame activity
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            float x = Input.GetAxis("Vertical");
            float z = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Rotate");
            transform.Rotate(new Vector3(x, y, -z));
        }
        
    }
}
