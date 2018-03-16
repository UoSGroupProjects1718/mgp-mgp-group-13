using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpJelly : MonoBehaviour
{

    public float jellyTime;
    public int jellyFactor;
    public static int p1JellyFactor = 0 , p2JellyFactor = 0;

    //sets fish speed mutiplier to bonus value 
    public void JellyPowerStartP1()
    {
        p2JellyFactor = jellyFactor;
        StartCoroutine(JellyPowerupTime(2));
    }

    public void JellyPowerStartP2()
    {
        p1JellyFactor = jellyFactor;
        StartCoroutine(JellyPowerupTime(1));
    }


    //coroutine for powerup time
    public IEnumerator JellyPowerupTime(int player)
    {
        yield return new WaitForSeconds(jellyTime);
        SpeedPowerStop(player);
    }


    //sets fish speed mutiplier to normal
    void SpeedPowerStop(int player)
    {
        if (player == 1) p1JellyFactor = 0;
        if (player == 2) p2JellyFactor = 0;
    }

}