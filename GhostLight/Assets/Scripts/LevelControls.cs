using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControls : MonoBehaviour {
    private bool snap;
    private Vector3[] snapVectors;
    private Vector3[] snapRotations;
    private Vector3 normal;
	// Use this for initialization
	void Awake () {
        snap = false;
        snapRotations = new Vector3[] { new Vector3(0, 0, 0), new Vector3(90, 0, 0), new Vector3(0, 90, 90), new Vector3(0, 270, 270) };
        snapVectors = new Vector3[] {
            new Vector3(0,1,0), //Up
            new Vector3(0, 0, 1), //South
            new Vector3(-1, 0, 0), //East
            new Vector3(1, 0, 0), //West
            new Vector3(0,0,-1), //North
            new Vector3(0, -1, 0) //Down
        };
        normal = new Vector3(0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Update is called regardless of frame activity
    void FixedUpdate()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Rotate");
        float angleX = transform.rotation.eulerAngles.x;
        float angleY = transform.rotation.eulerAngles.y;
        float angleZ = transform.rotation.eulerAngles.z;
        if (Input.GetKeyDown(KeyCode.Space)) { snap = !snap; }
        if (!snap)
        {
            print("X: " + angleX + " Y: " + angleY + " Z: " + angleZ);
            RotateLevel(x,y,z);
        }
        else {
            RotateLevel(x,y,z);
            //--------------------SNAPS LEVEL POSITION TO NEAREST FACE-------------------------------------------------
            {
                print("Close to Origin: " + normal +" - "+ snapVectors[0] + " = " + Vector3.Angle(normal, snapVectors[0]));
                if (Vector3.Angle(normal, snapVectors[0]) < 10.0f)
                {
                    transform.eulerAngles = snapRotations[0];
                    snap = false;
                }/*
                if (Vector3.Distance(transform.eulerAngles, snapAngles[3]) < 5.0f)
                {
                    transform.eulerAngles = snapAngles[3];
                    snap = false;
                }
                if (Vector3.Distance(transform.eulerAngles, snapAngles[0]) < 5.0f || Vector3.Distance(transform.eulerAngles, snapAngles[0]) > 355.0f)
                {
                    transform.eulerAngles = snapAngles[0];
                    snap = false;
                }
                if (Vector3.Distance(transform.eulerAngles, snapAngles[1]) < 10.0f || Vector3.Distance(transform.eulerAngles, snapAngles[1]) > 254.0f)
                {
                    transform.eulerAngles = snapAngles[1];
                    snap = false;
                }*/
            }
           
        }
        
    }
    void RotateLevel(float x, float y, float z) {
        normal = Quaternion.Euler(x, y, -z) * normal;
        transform.Rotate(new Vector3(x, y, -z));
    }
    public void ChangeSnap() {
        if (Input.GetKey(KeyCode.Space)) { snap = !snap; }
    }
}
