using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed;
    public bool alive = true;
    public GameObject mesh;
	// Use this for initialization
	void Start () {

	}

    void Awake() {
        
    }

    // Update is called regardless of frame activity
    void FixedUpdate()
    {
        if (alive)
        {
            float x = Input.GetAxis("HorizontalArrow");
            float z = Input.GetAxis("VerticalArrow");
            transform.position += transform.forward * (speed) * z;
            transform.Rotate(transform.up, x * (1 / (2 * speed)));
        }
        else {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    bool isAlive() {
        return alive;
    }
}
