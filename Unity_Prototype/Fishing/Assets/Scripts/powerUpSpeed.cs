using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpeed : MonoBehaviour {

    public float speedTime;
    public int speedRatio;
    
    //sets fish speed mutiplier to bonus value 
    public void SpeedPowerStartP1()
    {

        TwoPlayerController.fishBonusSpeedP2 = speedRatio;
        StartCoroutine(SpeedPowerupTime(2));

    }

    public void SpeedPowerStartP2()
    {

        TwoPlayerController.fishBonusSpeedP1 = speedRatio;
        StartCoroutine(SpeedPowerupTime(1));

    }


    //coroutine for powerup time
    public IEnumerator SpeedPowerupTime(int player)
    {
    
        yield return new WaitForSeconds(speedTime);
        SpeedPowerStop(player);
    }


    //sets fish speed mutiplier to normal
    void SpeedPowerStop(int player)
    {
        if (player == 1)
        TwoPlayerController.fishBonusSpeedP1 = 1;

        if (player ==2)
        TwoPlayerController.fishBonusSpeedP2 = 1;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
       
        
	}
}
