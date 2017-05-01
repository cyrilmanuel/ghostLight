using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLevelControl : MonoBehaviour
{
    private bool snap;
    private Vector3[] snapVectors;
    private Vector3[] snapRotations;
    private Vector3 normal;
    private float snapthreshold;
    public GameObject levelbase;
    public float distance;
    // Use this for initialization
    void Awake()
    {
        snap = false;
        snapthreshold = 20.0f;
        snapVectors = new Vector3[] {
            new Vector3(0,distance,0), //Up
            new Vector3(0, 0, distance), //South
            new Vector3(-distance, 0, 0), //East
            new Vector3(distance, 0, 0), //West
            new Vector3(0,0,-distance), //North
            new Vector3(0, -distance, 0) //Down
        };
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called regardless of frame activity
    void FixedUpdate()
    {
        float pitch = Input.GetAxis("Vertical");
        float roll = Input.GetAxis("Horizontal");
		if (Input.GetKeyDown(KeyCode.Space) && SplashOnLoad.isFinished) { snap = !snap; }
        if (!snap)
        {
            RotateLevel(roll, pitch);
        }
        else
        {
            RotateLevel(roll, pitch);
            //--------------------SNAPS LEVEL POSITION TO NEAREST FACE-------------------------------------------------
            {
                if (Vector3.Angle(transform.forward, snapVectors[5]) < snapthreshold)
                {
                    transform.position = snapVectors[0];
                    transform.LookAt(levelbase.transform);
                    snap = false;
                }
                if (Vector3.Angle(transform.forward, snapVectors[4]) < snapthreshold)
                {
                    transform.position = snapVectors[1];
                    transform.LookAt(levelbase.transform);
                    snap = false;
                }
                if (Vector3.Angle(transform.forward, snapVectors[3]) < snapthreshold)
                {
                    transform.position = snapVectors[2];
                    transform.LookAt(levelbase.transform);
                    snap = false;
                }
                if (Vector3.Angle(transform.forward, snapVectors[2]) < snapthreshold)
                {
                    transform.position = snapVectors[3];
                    transform.LookAt(levelbase.transform);
                    snap = false;
                }
                if (Vector3.Angle(transform.forward, snapVectors[1]) < snapthreshold)
                {
                    transform.position = snapVectors[4];
                    transform.LookAt(levelbase.transform);
                    snap = false;
                }
                if (Vector3.Angle(transform.forward, snapVectors[0]) < snapthreshold)
                {
                    transform.position = snapVectors[5];
                    transform.LookAt(levelbase.transform);
                    snap = false;
                }
            }
        }

    }
    void RotateLevel(float roll, float pitch)
    {
		if(SplashOnLoad.isFinished){
        transform.LookAt(levelbase.transform);
        transform.RotateAround(new Vector3(0, 0, 0), transform.up, -roll*((transform.rotation.x%90 + 1)));
        transform.RotateAround(new Vector3(0, 0, 0), transform.right, pitch);
		}
	}
}
