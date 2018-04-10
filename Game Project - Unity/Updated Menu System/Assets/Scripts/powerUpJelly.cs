using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUpJelly : MonoBehaviour
{
    public Button p1button, p2button;

    public float jellyTime;
    public int jellyFactor;
    public static int p1JellyFactor = 0 , p2JellyFactor = 0;
    public static bool p1Ready = false, p2Ready = false;


    //sets fish speed mutiplier to bonus value 
    public void JellyPowerStartP1()
    {
        p2JellyFactor = jellyFactor;
        p1Ready = false;
        p1button.interactable = false;
        StartCoroutine(JellyPowerupTime(2));
    }

    public void JellyPowerStartP2()
    {
        p1JellyFactor = jellyFactor;
        p2Ready = false;
        p2button.interactable = false;
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

    private void Start()
    {

    }



    void Update()
    {
        if (p1Ready) p1button.interactable = true;
        

        if (p2Ready) p2button.interactable = true;
        //else p2button.interactable = false;
   }
}