using UnityEngine;
using System.Collections;

public class TNT : MonoBehaviour
{

    float ExplosionForze;
    public GameObject Explosion;
    Ball TheBall;
    GameObject BallObject;
    bool triggered;
    Vector3 Direction;

    // Use this for initialization
    void Start()
    {
        triggered = false;
        BallObject = GameObject.Find("RollerBall");
        TheBall = (Ball)BallObject.GetComponent(typeof(Ball));
        ExplosionForze = 200;

    }

    // Update is called once per frame
    void Update()
    {

        float speedX = BallObject.GetComponent<Rigidbody>().velocity.x;
        float speedY = BallObject.GetComponent<Rigidbody>().velocity.y;
        Direction.x = speedX;
        Direction.y = speedY;
        Direction.z = 0;
        

    }

    void OnCollisionEnter(Collision impact)
    {
        

        if (impact.collider.name == BallObject.name && !triggered && TheBall.Fire)
        {
            print("Collision with dynamite activated");
            //ContactPoint[] contactP = impact.contacts;
            //Direction = theBall.transform.position - transform.position;
            //print(Direction);
            //theBall.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForze, theBall.transform.position , 10);
            Direction = -Direction;
            BallObject.GetComponent<Rigidbody>().AddForce(Direction * ExplosionForze);
            print(Direction);
            gameObject.SetActive(false);
            Instantiate(Explosion, transform.position, transform.rotation);
            triggered = true;
        }
        
        
    }

}