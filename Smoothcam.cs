using UnityEngine;
using System.Collections;

public class Smoothcam : MonoBehaviour {

    //Vector3 original_camera_pos;
    GameObject UInterface;
    LVL_controler control;


    // Use this for initialization
    void Start () {

        UInterface = GameObject.Find("UI");
       // original_camera_pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        GameObject theBall = GameObject.Find("RollerBall");
        control = (LVL_controler)UInterface.GetComponent(typeof(LVL_controler));
        float MaxZoomValue = -50;
        float MinZoomValue = -30;// The amount zoomed out (could be a proportion) and Original position
        float Speed = 33;

        //Camera adapts to balls position

        // X - Axis
        float Xdiff;
        float Ydiff;

        Xdiff = theBall.transform.position.x - Camera.main.transform.position.x;
        Ydiff = theBall.transform.position.y - Camera.main.transform.position.y;

        if (Xdiff != 0) // + X Statement
        {
            Camera.main.transform.Translate( Xdiff / 2, 0, 0);
        }

        if(Ydiff != 0) // + X Statement
        {
            Camera.main.transform.Translate(0, Ydiff / 2,  0);
        }


        //Debugging
        //print("X " + Camera.main.transform.position.x + ";  Y "+ Camera.main.transform.position.y);

        //DO MOVE


        // ZOOM OUT / IN
        if (Input.touchCount>0 && Camera.main.transform.position.z >= MaxZoomValue && control.gameRunning) // z is held down to max zoom
            {
            
            if (Camera.main.transform.position.z < MaxZoomValue + 1)
                {
                    print("Reached MaxZoomValue");
                    // Camera.main.transform.position = Camera.main.transform.forward * MaxZoomValue;
                }
                else
                {
                    Camera.main.transform.position -= Camera.main.transform.forward * Time.smoothDeltaTime * Speed;
                    // transform.position.z = transform.position.z + zoomValue;
                    print(Camera.main.transform.position.z + " * zoom out *");
                }


            }




            else if (Camera.main.transform.position.z < MinZoomValue) //AccelerationEvent RIGHT WAY
            {
                Camera.main.transform.position += Camera.main.transform.forward * Time.smoothDeltaTime * Speed;
                //transform.position.z = transform.position.z + zoomValue;
                print(Camera.main.transform.position.z + "   *zoom in*");

            }
      //  else 
            //Camera.main.transform.position.z = 29.72;

    }
}
