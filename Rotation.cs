using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {



    /*
        This is a tool that allows control of the frame during testings in PC version
        Has no use in during the android build
        
        */

    float speed = 0;
    float acceleration = 0;

    // Use this for initialization
    void Start () {
       // Mesh maze = GameObject.Find("Frame").GetComponent<Mesh>();
        
    }


    void OnCollisionEnter(Collision impact)
    {

        GameObject impact_object = impact.collider.gameObject;
        //print(impact_object.GetComponentInChildren.gameObject.name);
        //if (impact.transform.gameObject.name == Ball.name && this.picked == false)
        if (impact_object.name == "RollerBall")
        {
            //impact_object.GetComponent<Rigidbody>().velocity = -impact_object.GetComponent<Rigidbody>().velocity;            //impact.transform.transform.
            print("collision with frame");
        }
    }

    // Update is called once per frame
    void Update () {


   


        // Mesh maze = GameObject.Find("Maze").GetComponent<Mesh>();
        //Rotation maze = new Rotation;


        if (Input.GetKey("e")) //AccelerationEvent RIGHT WAY
        {

            if (speed < 0)
                acceleration = 4;
            else
                acceleration = 2;
            
            
           if (speed < 180)
                speed += acceleration ;
           else
                speed = 180;
        }

        else if (Input.GetKey("q")) //AccelerationEvent LEFT WAY
        {
            if (speed > 0)
                acceleration = -4;
            else
                acceleration = -2;
            speed += acceleration ;

            if (speed > -180)
                speed += acceleration;
            else
                speed = -180;
        }
        
    
        else  //SLOW DOWN
        {
            
            if (speed > 2)
            {
                acceleration = -2;
                speed += acceleration;
            }
                
            else if (speed < -2)
            {
                acceleration = 2;
                speed += acceleration;
            }
            else
                speed = 0;
        }
        transform.Rotate(-Vector3.back , speed * Time.deltaTime);
    }

        //transform.Rotate(-Vector3.up * speed * Time.deltaTime); USEFULL FOR SHAKING
}
