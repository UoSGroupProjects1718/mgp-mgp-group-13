using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class powerUpJelly : MonoBehaviour
{

    public float jellyTime;
    public int jellyFactor;
    public static int p1JellyFactor = 0 , p2JellyFactor = 0;
    public bool p1Ready = false, p2Ready = false;

    
    //sets fish speed mutiplier to bonus value 
        public void JellyPowerStartP1()
    {
        p2JellyFactor = jellyFactor;
        p1Ready = false;
        StartCoroutine(JellyPowerupTime(2));
    }

    public void JellyPowerStartP2()
    {
        p1JellyFactor = jellyFactor;
        p2Ready = false;
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