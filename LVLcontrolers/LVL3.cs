using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class LVL3 : LVL_controler
{


    // Use this for initialization
    void Start()
    {
        lvlname = "T-N-T";
        lvlnumber = 3;
        lvl_timer = 90;

        GameMenuLose = GameObject.Find("LoseMenu");
        GameMenuWin = GameObject.Find("WinMenu");
        NameText = GameObject.Find("LvlName").GetComponent<Text>();
        CountText = GameObject.Find("Counter").GetComponent<Text>();
        LvlNumber = GameObject.Find("LvlNumber").GetComponent<Text>();

        NameText.text = lvlname;
        LvlNumber.text = lvlnumber.ToString();
        CountText.text = lvl_timer.ToString();
        
        initLevel();
    }

    // Update is called once per frame  DECLARED IN THE ORIGINAL FUNCTION
    /*
	void Update () {

    }
    */
}