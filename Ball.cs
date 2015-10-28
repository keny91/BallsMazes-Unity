using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour {
    float weight;
    public bool Fire;
    GameObject Ball_Particles_Fire;
    LVL_controler control;
    GameObject RespanwPoint;
    GameObject UInterface;
    GameObject ObjectBall;
    LVL_controler nLVL;



    //bool metal;
    //bool balloon;

        /*
           int material; // Value from 0 to 3
          0 -> normal; 1 -> fire; 
          2 -> metalic; 3 -> Balloon
    * /



    public Ball() {
        weight = 1;
        //acceleration_mod = 1;
        // set standard form
    }


    /*
        BLINK. During respawn the ball will blink for some time, the ball is not invulnerable during this time.
        This code is a pre-made method taken from stackOverFlow
   */

    void BlinkPlayer(int numBlinks)
    {
        StartCoroutine(DoBlinks(numBlinks, 0.2f));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks * 2; i++)
        {

            //toggle renderer
            gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
            //wait for a bit
            yield return new WaitForSeconds(seconds);
        }

        //make sure renderer is enabled when we exit
        gameObject.GetComponent<Renderer>().enabled= true;
    }


    /*
    RESPAWN. Restarts the original position of the ball. DOES NOT restart status.
 */

    public void Respawn()
    {
        RespanwPoint = GameObject.Find("Respawn");  // some calls to this method are external so it requires an initialized value
        gameObject.transform.position = RespanwPoint.transform.position;   // Set position to spawn
        GetComponent<Rigidbody>().velocity = Vector3.zero;    // RESET Velocity
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        print("Ball Respawned");

        //Blink();
        BlinkPlayer(3); // 3 blink loops


    }


    /*
        The ball may collide with many different objects, some may trigger events
        */

    void OnTriggerEnter(Collider impact)
    {
        //Case 1: BALL collided with an object that will kill
        if (impact.tag == "KillObject")
        {

            nLVL = (LVL_controler)UInterface.GetComponent(typeof(LVL_controler));
            nLVL.DeathPenalty();
            Respawn();
            print("Ball killed");
        }

     

        /*
            Detect that the ball has gone into the cave
        */
        if (impact.name == "CaveIn")
        {
            GameObject[] frontCave;
            frontCave = GameObject.FindGameObjectsWithTag("FrontCave");

            for (int i = 0; i < frontCave.Length; i++)
            {

                frontCave[i].GetComponent<Renderer>().enabled = false;

            }
           
            print("Ball in the cave");
        }




        /*
           Detect that the ball has gone OUT of the cave
       */

        if (impact.name == "CaveOut")
        {
            GameObject[] frontCave;
            frontCave = GameObject.FindGameObjectsWithTag("FrontCave");

            for (int i = 0; i < frontCave.Length; i++)
            {
                //print(frontCave[i].name);
                frontCave[i].GetComponent<Renderer>().enabled = true;

            }

            print("Ball Out the cave");
        }




        /*
            The Ball has hit the win condition
        */

        if (impact.transform.gameObject.tag == "WinCondition")
        {        
            nLVL = (LVL_controler)UInterface.GetComponent(typeof(LVL_controler));
            nLVL.GoalReached();
            print("Level Passed"); //Debug info
        }

    }


    /*
    SET STATUS. Changes the attributes and physical apperance of the ball. Requires a 0 to 3 input
    */

    public void setStatus(int selection)
    {

        // Init any particles or materials necesary
        Ball_Particles_Fire = transform.Find("FireParticle").gameObject;

        // if the number happens to be larger than 3
        if (selection < 0 || selection > 3)
        {
            Fire=false;
            weight = 1;
            //acceleration_mod = 1;
            print("SError, status set to normal");

        }

        else
        {
            switch (selection)
            {
                // normal
                case 0:
                    weight = 1;
                    //acceleration_mod = 1;
                    Fire = false;
                    Ball_Particles_Fire.SetActive(false);
                    gameObject.GetComponent<Renderer>().material.SetColor("_SpecColor", Color.black);
                    print("Ball Status: normal");
                    
                    break;
                // fire
                case 1:

                    weight = 20;
                    Fire = true; 
                    //print("test ;  "+ Physics.gravity * rigidbal.mass);

                    Ball_Particles_Fire.SetActive(true);
                    gameObject.GetComponent<Renderer>().material.SetColor("_SpecColor", Color.red);
                    print("Ball Status: fire");
                    break;

                // metalic
                case 2:
                    weight = 100;
                    print("metal");
                    break;

                //
                case 3:
                    weight = 0.1f;
                    print("balloon");
                    break;
            }
        }

    }

    // Use this for initialization
    void Start () {

        RespanwPoint = GameObject.Find("Respawn");
        UInterface = GameObject.Find("UI");
        ObjectBall = GameObject.Find("RollerBall");
        setStatus(0);
        

    }
	
	// Update is called once per frame
	void Update () {


        control = (LVL_controler)UInterface.GetComponent(typeof(LVL_controler));
        //
        Vector3 gravityInput;
        Vector3 nullVector;
        nullVector.x = 0;
        nullVector.y = 0;
        nullVector.z = 0;
        Rigidbody rigidball;
        rigidball = gameObject.GetComponent<Rigidbody>();


        //Gravity depending on the acceleration ONLY ANDROID
        //Z = 0 so it does not feel like rolling
        if (control.gameRunning)
        {
           
            gravityInput = Input.acceleration.normalized;
            gravityInput.z = 0;
            Physics.gravity = 20 * gravityInput;
           

            if (Fire)
            {
                rigidball.AddForce(Physics.gravity * rigidball.mass);
            }
        }
        else
            rigidball.velocity= nullVector;
            
    }
}

