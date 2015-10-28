using UnityEngine;
using System.Collections;


/*
       VERY IMPORTANT THE STRUCTURE OF A PARTICLE POWERUP MUST BE OF THE STRUCTURE
           POWERUP_
               .CHILD PARTICLE 1  ->SPACE(0)
               .CHILD PARTICLE 2  ->SPACE(1)

       */




public class PowerUps : MonoBehaviour {

    protected bool picked;
    protected Ball theBall;
    protected GameObject objectBall;


    public PowerUps(bool i=false)
    {
        picked = i;
    }

    public void DeactivatePowerUP()
    {
        gameObject.tag = "BuildOnEnd";
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;
    }
  

    // This is the only method modified between powerUps -> instantiated in each powerUp
   virtual public void hitByBall()
    {

        Destroy(gameObject);
        picked = true;

    }



   virtual public void OnTriggerEnter(Collider impact)
    {
        //if (impact.transform.gameObject.name == Ball.name && this.picked == false)
        if (impact.transform.gameObject.name == "RollerBall" )
        {
            hitByBall();
            print("collision");
        }
    }
            

    // Use this for initialization
    public void Start () {
        GameObject objectBall = GameObject.Find("RollerBall");
        theBall = (Ball)objectBall.GetComponent(typeof(Ball));
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}

