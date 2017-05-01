using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControler : MonoBehaviour {
    public Vector3[] anchors;
    public float speed;
    public bool loop;
    private int point;
	// Use this for initialization
	void Start () {
        point = 0;
        transform.position = anchors[0];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float step = speed * Time.deltaTime;
        if (loop)
        {
            if (transform.position != anchors[(point + 1) % anchors.Length])
                transform.position = Vector3.MoveTowards(transform.position, anchors[(point + 1) % anchors.Length], step);
            else
                point += 1;
        }
        else {
            if (point == anchors.Length) {
                if (transform.position != anchors[point + 1])
                    transform.position = Vector3.MoveTowards(transform.position, anchors[point + 1], step);
                else
                    point += 1;
            }
        }
    }

}
