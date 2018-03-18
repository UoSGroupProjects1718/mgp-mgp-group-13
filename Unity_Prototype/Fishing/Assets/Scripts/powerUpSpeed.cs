using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpeed : MonoBehaviour {

    public float speedTime;
    public float speedRatio;
    public static float P1spawnRatio, P2spawnRatio;
    public bool p1Ready = false, p2Ready = false;

    //sets fish speed mutiplier to bonus value 
    public void SpeedPowerStartP1()
    {

        TwoPlayerController.fishBonusSpeedP2 = speedRatio;
        P2spawnRatio = (1f / speedRatio);
        p1Ready = false;
        //P2spawnRatio = 1;
        StartCoroutine(SpeedPowerupTime(2));

    }

    public void SpeedPowerStartP2()
    {

        TwoPlayerController.fishBonusSpeedP1 = speedRatio;
        P1spawnRatio = (1f / speedRatio);
        p2Ready = false;
        //P1spawnRatio = 1;
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
        P1spawnRatio = 1;

        if (player ==2)
        TwoPlayerController.fishBonusSpeedP2 = 1;
        P2spawnRatio = 1;
    }

    // Use this for initialization
    void Start ()
    {
        P1spawnRatio = 1;
        P2spawnRatio = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(speedRatio);
        //Debug.Log(P2spawnRatio);
       
        
	}
}
