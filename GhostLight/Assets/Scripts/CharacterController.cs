using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called regardless of frame activity
    void FixedUpdate()
    {
        float x = Input.GetAxis("HorizontalArrow");
        float z = Input.GetAxis("VerticalArrow");
        transform.position = new Vector3(x,transform.position.y,z);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
