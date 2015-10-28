using UnityEngine;
using UnityEngine.UI;
using System.Collections;



/*
       VERY IMPORTANT THE STRUCTURE OF A PARTICLE POWERUP MUST BE OF THE STRUCTURE
           POWERUP_
               .CHILD PARTICLE 1  ->SPACE(0)
               .CHILD PARTICLE 2  ->SPACE(1)

       */



public class LVL1 : LVL_controler {

    //int lvl_timer = 100;

	// Use this for initialization
	void Start () {
        lvlname = "Starting";
        lvlnumber = 1;
        lvl_timer = 120;

        GameMenuLose = GameObject.Find("LoseMenu");
        GameMenuWin = GameObject.Find("WinMenu");
        NameText = GameObject.Find("LvlName").GetComponent<Text>();
        CountText = GameObject.Find("Counter").GetComponent<Text>();
        //print("First--- "+CountText.text);
        LvlNumber = GameObject.Find("LvlNumber").GetComponent<Text>();
        

        NameText.text = lvlname;
        LvlNumber.text = lvlnumber.ToString();
        CountText.text = lvl_timer.ToString();
       // print("Second--- " + CountText.text);

        initLevel();
    }
	
	// Update is called once per frame  DECLARED IN THE ORIGINAL FUNCTION
    /*
	void Update () {

    }
    */
}
