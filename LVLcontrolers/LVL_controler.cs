using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
       VERY IMPORTANT THE STRUCTURE OF A PARTICLE POWERUP MUST BE OF THE STRUCTURE
           POWERUP_ tag(BuildOnEndParticleChild)
               .CHILD PARTICLE 1  ->SPACE(0)
               .CHILD PARTICLE 2  ->SPACE(1)

        Any other respawnable Objects just have to be defined
            DestructibleObject_ tag(BuildOnEnd)

   */
  



public class LVL_controler : MonoBehaviour {

   protected string lvlname = "Default";
   protected int lvlnumber = 666;
   protected float lvl_timer;
   protected float CurrentTime;
   protected float timeLeft;
   protected Text NameText;
   protected Text CountText;
   protected Text LvlNumber;

   protected Ball theBall;
   GameObject objectBall;
   protected GameObject[] RespawnableObjects;
   protected GameObject[] RespawnableObjectsWithParticles;
   protected GameObject[] MovingObjectsRotClockWise;
   public bool gameRunning;
   public bool gamePaused;

    AudioSource audioS;
    public AudioClip Agood, Abad, Adeath;
    

    public GameObject GameMenuLose;
    public GameObject GameMenuWin;



    /*
        GAME PAUSED/RESUMED
        */
    public void Paused()
    {
        
        gameRunning = false;
        gamePaused = true;
    }

    public void Resume()
    {
        gameRunning = true;
        gamePaused = false;
        //time_ref = (int)Time.time;
    }






    /*
        Determine if the Game has ended by time count
        
        */

    protected void TimeUp(float time)
    {
        if (time <= 0)
        {
            audioS = gameObject.AddComponent<AudioSource>();
            audioS.clip = Abad;
            audioS.Play();
            print("time UP!");
            GameMenuLose.SetActive(true);
            //NOT READING AFTER gameMenuLOSE
            
            Paused();
        }
    }

    // ON WIN-CONDITION

    public void GoalReached()
    {
        Paused();
        audioS = gameObject.AddComponent<AudioSource>();
        audioS.clip = Agood;
        audioS.Play();
        GameMenuWin.SetActive(true);
    }



    /*
        Methods assigned to buttons in the POP-up Menus
        */


    public void RetryButton()
    {
        /*
        LVL_controler nLVL = new LVL_controler();
        GameObject UInterface = GameObject.Find("UI");
        nLVL = (LVL_controler)UInterface.GetComponent(typeof(LVL_controler));
        nLVL.initLevel();
        */
        Application.LoadLevel(Application.loadedLevel);
    }

    // Method asigned to 
    public void NextLevelButton()
    {
        Application.LoadLevel(Application.loadedLevel+1);
    }

    public void MenuButton()
    {
        Application.LoadLevel(0);
    }




    /*
        If the ball dies apply a penalty
        */
    
    public void DeathPenalty()
    {
        audioS = gameObject.AddComponent<AudioSource>();
        audioS.clip = Adeath;
        audioS.Play();
        CurrentTime += 10;
        if (CurrentTime > lvl_timer)
            CurrentTime = lvl_timer;
    }

    /*
       INITLEVEL: restarts the current level, resets ball status and position; respawns any destructibles.
   */
    public void initLevel()
    {

        print("Level initialized");
        GameMenuLose = GameObject.Find("LoseMenu");
        GameMenuWin = GameObject.Find("WinMenu");
        RespawnableObjects = GameObject.FindGameObjectsWithTag("BuildOnEnd");
        RespawnableObjectsWithParticles = GameObject.FindGameObjectsWithTag("BuildOnEndParticleChild");

        // Initlevel may have an external call
        objectBall = GameObject.Find("RollerBall");
        theBall = (Ball)objectBall.GetComponent(typeof(Ball));



        //Default parameters
        Resume();
        GameMenuWin.SetActive(false);
        GameMenuLose.SetActive(false);
        theBall.Respawn();
        CountText.text = (lvl_timer).ToString();
        theBall.setStatus(0);
        CurrentTime = 0;

        for (int i = 0; i< RespawnableObjects.Length; i++)
        {
            print(RespawnableObjects[i].name);
            RespawnableObjects[i].GetComponent<Collider>().enabled = true;
            RespawnableObjects[i].GetComponent<Renderer>().enabled = true;


        }


        /*
        VERY IMPORTANT THE STRUCTURE OF A PARTICLE POWERUP MUST BE OF THE STRUCTURE
            POWERUP_
                .CHILD PARTICLE 1  ->SPACE(0)
                .CHILD PARTICLE 2  ->SPACE(1)
        
        */

        for (int i = 0; i <RespawnableObjectsWithParticles.Length; i++)
        {
            print("Respanwed: "+RespawnableObjectsWithParticles[i].name);
            RespawnableObjectsWithParticles[i].GetComponent<Collider>().enabled = true;
            RespawnableObjectsWithParticles[i].transform.GetChild(0).GetComponent<ParticleSystem>().enableEmission = true;
            RespawnableObjectsWithParticles[i].transform.GetChild(1).GetComponent<ParticleSystem>().enableEmission = true;

        }

    }




    // Use this for initialization
    void Start () {
        

        audioS = gameObject.AddComponent<AudioSource>();
        

        objectBall = GameObject.Find("RollerBall");
        theBall = (Ball)objectBall.GetComponent(typeof(Ball));
        theBall.Respawn();
        print("BALL AT START during the beggining");
        initLevel();
        

    }
	
	// Update is called once per frame
	void Update () {
        int ThirdTime = (int)(lvl_timer/3);
        int TenSeconds = 10;
        


        if (gameRunning)
        {
            // TIME UPDATE
            CurrentTime += Time.deltaTime;
            timeLeft = lvl_timer - CurrentTime;
            timeLeft = Mathf.Round(timeLeft);
            CountText.text = timeLeft.ToString();
            TimeUp(timeLeft);

            // COLOR CHANGE
            if (timeLeft < ThirdTime)
            {
                if (timeLeft < TenSeconds)
                    CountText.color = Color.red;
                else
                    CountText.color = Color.yellow;

            }
            else
            {
                CountText.color = Color.black;
            }




            //objectBall.OnTriggerEnter(collider);
        }






        // IF PAUSED
        else
        {


        }


    }
}
