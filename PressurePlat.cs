using UnityEngine;
using System.Collections;

public class PressurePlat : MonoBehaviour {

    GameObject pressurePlat;
    GameObject DoorL, DoorR;
    bool pressed;
    float transformScaleDoors, transformScalePlate;
    Vector3 DoorScale;
    Vector3 PlatScale;

    // Use this for initialization
    void Start () {
        transformScaleDoors = 0.31f;
        transformScalePlate = 0.38f;
        pressed = false;
        DoorL = GameObject.Find("DoorLeft");
        DoorR = GameObject.Find("DoorRight");
        pressurePlat = GameObject.Find("PreassurePlate");


        // Vector values
        /*
        DoorScale.x = transformScaleDoors;
        DoorScale.y = 1;
        DoorScale.z = 1;
        PlatScale.x = 1;
        PlatScale.y = transformScalePlate;
        PlatScale.z = 1;
        */
    }

  
    // Detect collision with ball
    void OnTriggerEnter(Collider impact)
    {
        // only if it is the first time colision -> Re-scale
        if (impact.transform.gameObject.name == "RollerBall" && pressed==false)
        {

          DoorScale = new Vector3(transformScaleDoors, 1,1);
          PlatScale = new Vector3(1, transformScalePlate, 1);
          
           DoorL.transform.localScale = Vector3.Scale(DoorL.transform.localScale, DoorScale);
           DoorR.transform.localScale = Vector3.Scale(DoorR.transform.localScale, DoorScale);
           pressurePlat.transform.localScale = Vector3.Scale(pressurePlat.transform.localScale, PlatScale);
           
            pressed = true;
            print("ButtonPressed");
        }
    }



    // Update is called once per frame
    void Update () {

        
    }
}
