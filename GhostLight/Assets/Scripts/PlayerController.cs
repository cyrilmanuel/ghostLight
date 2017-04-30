using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float speed;
	// Use this for initialization
	void Start () {
        speed = 0.025f;
	}

    // Update is called regardless of frame activity
    void FixedUpdate()
    {
        float x = Input.GetAxis("HorizontalArrow");
        float z = Input.GetAxis("VerticalArrow");
        transform.Translate(transform.forward * (speed) * z);
        transform.Rotate(transform.up, x*0.25f/speed);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
