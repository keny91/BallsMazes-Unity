using UnityEngine;
using System.Collections;



/*
       VERY IMPORTANT THE STRUCTURE OF A PARTICLE POWERUP MUST BE OF THE STRUCTURE
           POWERUP_
               .CHILD PARTICLE 1  ->SPACE(0)
               .CHILD PARTICLE 2  ->SPACE(1)

       */





public class FirePower : PowerUps {

    
    

   override public void hitByBall()
    {
        //ADD PARTICLE EFFECT
        objectBall = GameObject.Find("RollerBall");
        theBall = (Ball)objectBall.GetComponent(typeof(Ball));
        gameObject.tag = "BuildOnEndParticleChild";        // SPECIAL INACTIVE CASE
        theBall.setStatus(1);
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().enableEmission = false;
        gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().enableEmission = false;
        picked = true;
        print(gameObject.tag);
        //print("message firepower");


    }

    override public void OnTriggerEnter(Collider impact)
    {
        //if (impact.transform.gameObject.name == Ball.name && this.picked == false)
        if (impact.transform.gameObject.name == "RollerBall")
        {
            hitByBall();
            print("collision with powerup");
        }
    }

    // Use this for initialization
    /*
    public void Start()
    {
        
    }
    */

    // Update is called once per frame
    void Update () {
	
	}
}

