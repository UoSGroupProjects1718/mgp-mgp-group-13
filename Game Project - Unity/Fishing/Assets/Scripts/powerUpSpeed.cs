using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUpSpeed : MonoBehaviour {

    public Button p1button, p2button;

    public float speedTime;
    public float speedRatio;
    public static float P1spawnRatio, P2spawnRatio;
    public static bool p1Ready = false, p2Ready = false;

    public GameObject p1Storm, p2Storm;
<<<<<<< HEAD
=======

>>>>>>> 2faf2d19c2f26fde8c0480437af114d96eb29be7

    //sets fish speed mutiplier to bonus value 
    public void SpeedPowerStartP1()
    {

        TwoPlayerController.fishBonusSpeedP2 = speedRatio;
        P2spawnRatio = (1f / speedRatio);
        p1Ready = false;
        p1button.interactable = false;
        //P2spawnRatio = 1;
        StartCoroutine(SpeedPowerupTime(2));
        p2Storm.SetActive(true);

    }

    public void SpeedPowerStartP2()
    {

        TwoPlayerController.fishBonusSpeedP1 = speedRatio;
        P1spawnRatio = (1f / speedRatio);
        p2Ready = false;
        p2button.interactable = false;
        //P1spawnRatio = 1;
        StartCoroutine(SpeedPowerupTime(1));
        p1Storm.SetActive(true);

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
        {
            TwoPlayerController.fishBonusSpeedP1 = 1;
            P1spawnRatio = 1;
            p1Storm.SetActive(false);
        }

        if (player == 2)
        {
            TwoPlayerController.fishBonusSpeedP2 = 1;
            P2spawnRatio = 1;
            p2Storm.SetActive(false);
        }
    }

    // Use this for initialization
    void Start ()
    {
        P1spawnRatio = 1;
        P2spawnRatio = 1;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
