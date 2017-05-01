using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float speed;
    public GameObject mesh;
	// Use this for initialization
	void Start () {
        speed = 0.05f;
	}

    void Awake() {
        
    }

    // Update is called regardless of frame activity
    void FixedUpdate()
    {
        float x = Input.GetAxis("HorizontalArrow");
        float z = Input.GetAxis("VerticalArrow");
        transform.position += transform.forward * (speed) * z;
        transform.Rotate(transform.up, x*(1/(2*speed)));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
