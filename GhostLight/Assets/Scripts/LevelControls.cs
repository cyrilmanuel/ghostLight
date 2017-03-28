using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControls : MonoBehaviour {
    private bool snap;
    private Vector3[] snapAngles;
	// Use this for initialization
	void Awake () {
        snap = false;
        snapAngles = new Vector3[] { new Vector3(0,0,0), new Vector3(90, 0, 0), new Vector3(0, 90, 90), new Vector3(0, 270, 270) };
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
                print("Distance to origin: " + Vector3.Distance(transform.eulerAngles, snapAngles[3]));
                if (Vector3.Distance(transform.eulerAngles, snapAngles[0]) < 5.0f || Vector3.Distance(transform.eulerAngles, snapAngles[0]) > 355.0f)
                {
                    transform.eulerAngles = snapAngles[0];
                    snap = false;
                }
                if (Vector3.Distance(transform.eulerAngles, snapAngles[1]) < 10.0f || Vector3.Distance(transform.eulerAngles, snapAngles[1]) > 254.0f)
                {
                    transform.eulerAngles = snapAngles[1];
                    snap = false;
                }
                if (Vector3.Distance(transform.eulerAngles, snapAngles[2]) < 5.0f)
                {
                    transform.eulerAngles = snapAngles[2];
                    snap = false;
                }
                if (Vector3.Distance(transform.eulerAngles, snapAngles[3]) < 5.0f)
                {
                    transform.eulerAngles = snapAngles[3];
                    snap = false;
                }

            }
           
        }
        
    }
    void RotateLevel(float x, float y, float z) {
        transform.Rotate(new Vector3(x, y, -z));
    }
    public void ChangeSnap() {
        if (Input.GetKey(KeyCode.Space)) { print("reversing snap"); snap = !snap; }
    }
}
