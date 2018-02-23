using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerController : MonoBehaviour {

    public GameObject P1Line, P2Line; // references to each players line objects
    public float P1_yMin, P1_yMax, speed; // set in unity, tweakable limits for movement of lines.
    public bool lineDown, lineMoving, inputClicked; // used internally to animate lines.
    private int P1Score = 0, P2Score = 0;

    // Use this for initialization
    void Start()
    {
        lineDown = false; // makes sure that the line is in its starting position
        lineMoving = false;
    }

    // Update is called once per frame
    void Update()
    {

     

        if (Input.GetButton("Fire1") && lineMoving == false && lineDown == false) // the player taps, the line isn't already moving and its current position is up
        {
            lineMoving = true;  // set the line as moving
            downFrame();        // animate a frame of downward movement
        }

        if (Input.GetButton("Fire1") && lineMoving == false && lineDown == true) // the player taps, the line isn't already moving and its current position is down
        {
            lineMoving = true;  //set the line as moving
            upFrame();          // animate a frame of upward movement
        }


        if (lineMoving == (true) && lineDown == false)  // if the line is already moving and its last complete position was up
        {
            downFrame();                                // animate a down frame
        }

        if (lineMoving == (true) && lineDown == true)   // if the line is already moving and its last complete position was down
        {   
            upFrame();                                  // animate an up frame
        }
       
    }


    // define functions for animating frames of line movement
    public void downFrame()
    {
        if (P1Line.transform.position.y > P1_yMin)  // check the lines arent beyond the limits (only check once using P1's line positions as they will always move in perfect syncronisation and prevent logic conflicts
        {
            P1Line.transform.position += new Vector3(0.0f, -0.1f * speed * Time.deltaTime, 0.0f);   
            P2Line.transform.position += new Vector3(0.0f, -0.1f * speed * Time.deltaTime, 0.0f);
        }
        if (P1Line.transform.position.y <= P1_yMin) // when the lines meet the limits flip the line positon and stop the line moving
        {
            lineDown = true;
            lineMoving = false;
        }

    }

    public void upFrame()
    {
        if (P1Line.transform.position.y < P1_yMax) // as above
        {
            P1Line.transform.position += new Vector3(0.0f, 0.1f * speed * Time.deltaTime, 0.0f);
            P2Line.transform.position += new Vector3(0.0f, 0.1f * speed * Time.deltaTime, 0.0f);
        }
        if (P1Line.transform.position.y >= P1_yMax) // as above
        {
            lineDown = false;
            lineMoving = false;
        }

    }

    public void addScore(int PlayerRef, int scoreValue)
    {
        if (PlayerRef == 1)
        {
            P1Score += scoreValue;
        }
        if (PlayerRef == 2)
        {
            P2Score += scoreValue;
        }

        print("Player1: " + P1Score.ToString());
        print("Player2: " + P2Score.ToString());
    }
}
