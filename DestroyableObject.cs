using UnityEngine;
using System.Collections;

public class DestroyableObject : MonoBehaviour {

    GameObject BallObject;
    public GameObject ExplosionParticles;
    public float speedTH;
    Ball TheBall;
    float speed;
    Vector3 speedV;

    // Use this for initialization
    void Start () {
        BallObject = GameObject.Find("RollerBall");
        TheBall = (Ball)BallObject.GetComponent(typeof(Ball));
        
    }
	
    void OnCollisionEnter(Collision impact)
    {
        
        /*
        try to reduce velocity to 1/2 after impact
        */


        if (impact.collider.name == "RollerBall") { 
            //Destroy if ball has a minimum speed and has the fire

            
            // print(speed + "FireStatus = "+ TheBall.Fire);
            //print("Collision "+((speedTH )-speed));

            if (TheBall.Fire && speed > speedTH )
            {

                Instantiate(ExplosionParticles, transform.position, transform.rotation);
                gameObject.SetActive(false);
                BallObject.GetComponent<Rigidbody>().velocity = speedV / 3;
                print("Wall Destroyed");
            }

        }
    }

	// Update is called once per frame
	void Update () {
        float speedX = BallObject.GetComponent<Rigidbody>().velocity.x;
        float speedY = BallObject.GetComponent<Rigidbody>().velocity.y;
        speed = Mathf.Sqrt(Mathf.Pow(speedX, 2) + Mathf.Pow(speedY, 2));
        speedV = BallObject.GetComponent<Rigidbody>().velocity / 3;

    }
}
