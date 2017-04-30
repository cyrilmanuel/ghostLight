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
    // Use this for initialization
    void Awake()
    {
        snap = false;
        snapRotations = new Vector3[] {
            new Vector3(0, 0, 0), //Up
            new Vector3(90, 0, 180), //South
            new Vector3(0, 90, 270), //East
            new Vector3(0, 270, 90), //West
            new Vector3(270,0,0), //North
            new Vector3(360,0,0) //Down
        };
        snapVectors = new Vector3[] {
            new Vector3(0,1,0), //Up
            new Vector3(0, 0, 1), //South
            new Vector3(-1, 0, 0), //East
            new Vector3(1, 0, 0), //West
            new Vector3(0,0,-1), //North
            new Vector3(0, -1, 0) //Down
        };
        normal = new Vector3(0, 1, 0);
        snapthreshold = 20.0f;
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
        float yaw = Input.GetAxis("Rotate");
        if (Input.GetKeyDown(KeyCode.Space)) { snap = !snap; }
        if (!snap)
        {
            //print("X: " + angleX + " Y: " + angleY + " Z: " + angleZ);
            RotateLevel(roll, pitch, yaw);
            
        }
        else
        {
            RotateLevel(roll, pitch, yaw);
            //--------------------SNAPS LEVEL POSITION TO NEAREST FACE-------------------------------------------------
            {
                //print("Close to Origin: " + normal + " - " + snapVectors[5] + " = " + Vector3.Angle(snapVectors[5], normal));
                if (Vector3.Angle(normal, snapVectors[0]) < snapthreshold)
                {
                    transform.eulerAngles = snapRotations[0];
                    snap = false;
                }
                if (Vector3.Angle(normal, snapVectors[1]) < snapthreshold)
                {
                    transform.eulerAngles = snapRotations[1];
                    snap = false;
                }
                if (Vector3.Angle(normal, snapVectors[2]) < snapthreshold)
                {
                    transform.eulerAngles = snapRotations[2];
                    snap = false;
                }
                if (Vector3.Angle(normal, snapVectors[3]) < snapthreshold)
                {
                    transform.eulerAngles = snapRotations[3];
                    snap = false;
                }
                if (Vector3.Angle(normal, snapVectors[4]) < snapthreshold)
                {
                    transform.eulerAngles = snapRotations[4];
                    snap = false;
                }
                if (Vector3.Angle(normal, snapVectors[5]) < snapthreshold)
                {
                    transform.eulerAngles = snapRotations[5];
                    snap = false;
                }
            }
        }

    }
    void RotateLevel(float roll, float pitch, float yaw)
    {
        //normal = Quaternion.Euler(x, y, -z) * normal;
        transform.LookAt(levelbase.transform);
        transform.Rotate(new Vector3(0, 0, 1), yaw*360/Mathf.PI);
        transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), -roll);
        transform.RotateAround(new Vector3(0, 0, 0), new Vector3(1, 0, 0), pitch);
    }
}
