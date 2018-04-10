using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTextController : MonoBehaviour {

    public Text p1P1Score, p1P2Score, p1Text, p2P1Score, p2P2Score, p2Text;
    private int P1Score, P2Score;

    void hasWon()
    {
        
    }
    
	void Start ()
    {
        //gets scores from other script
        P1Score = TwoPlayerController.P1Score;
        P2Score = TwoPlayerController.P2Score;
    }

    void Update()

    {
        //sets both players score displays
        p1P1Score.text = "P1 " + P1Score.ToString();
        p1P2Score.text = "P2 " + P2Score.ToString();
        
        p2P1Score.text = "P1 " + P1Score.ToString();
        p2P2Score.text = "P2 " + P2Score.ToString();



        //sets the win / lose screen's for both players or a draw
        if (P1Score > P2Score)
            {
            p1Text.text = "you Win!";
            p2Text.text = "you Lose!";
            }

        if (P2Score > P1Score)
        {
            p1Text.text = "you Lose!";
            p2Text.text = "you Win!";
        }

        if (P2Score == P1Score)
        {
            p1Text.text = "DRAW";
            p2Text.text = "DRAW";
        }



    }
}
