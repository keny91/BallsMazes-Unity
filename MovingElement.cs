using UnityEngine;
using System.Collections;

public class MovingElement : MonoBehaviour {

    public float speed;



    // Use this for initialization
    void Start () {
        // RespawnableObjects = GameObject.FindGameObjectsWithTag("BuildOnEnd");
        speed = 18;
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.tag=="MovingClock")
        transform.Rotate(-Vector3.back, speed * Time.deltaTime);
        else if(transform.tag == "MovingAntiClock")
        transform.Rotate(Vector3.back, speed * Time.deltaTime);
    }
}
