using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerController : MonoBehaviour {

    public GameObject P1Line, P2Line;
    public float P1_yMin, P1_yMax, P2_yMin, P2_yMax, speed;
    private bool lineDown, lineMoving, inputClicked;


    // Use this for initialization
    void Start()
    {
        lineDown = false;
        lineMoving = false;
        inputClicked = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && lineMoving == false && lineDown == false)
        {
            lineMoving = true;
            downFrame();
        }

            if (Input.GetButton("Fire1") && lineMoving == false && lineDown == true)
        {
            lineMoving = true;
            upFrame();
        }


        if (lineMoving == (true) && lineDown == false)
        {
            downFrame();
        }

        if (lineMoving == (true) && lineDown == true)
        {
            upFrame();
        }
    }

    void downFrame()
    {
        if (P1Line.transform.position.y > P1_yMin)
        {
            P1Line.transform.position += new Vector3(0.0f, -0.1f * speed * Time.deltaTime, 0.0f);
            P2Line.transform.position += new Vector3(0.0f, -0.1f * speed * Time.deltaTime, 0.0f);
        }
        if (P1Line.transform.position.y <= P1_yMin)
        {
            lineDown = true;
            lineMoving = false;
        }

    }

    void upFrame()
    {
        if (P1Line.transform.position.y < P1_yMax)
        {
            P1Line.transform.position += new Vector3(0.0f, 0.1f * speed * Time.deltaTime, 0.0f);
            P2Line.transform.position += new Vector3(0.0f, 0.1f * speed * Time.deltaTime, 0.0f);
        }
        if (P1Line.transform.position.y >= P1_yMax)
        {
            lineDown = false;
            lineMoving = false;
        }

    }

}
