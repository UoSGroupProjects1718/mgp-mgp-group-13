using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour {

    public float RoundTime;
    public GameObject marker;

    public Transform startMarker;
    public Transform endMarker;

    private float initialTime;


    void Start()
    {
        initialTime = RoundTime;
    }


    void Update()
    {
        // counts down
        if (RoundTime > 0)
        {
            RoundTime -= Time.deltaTime;
        }

        else if (RoundTime <= 0) // when counter reaches zero call end the level
        {
            // some code to make the level end and display final scores
        }



        float alpha = RoundTime / initialTime;
        marker.transform.position = Vector3.Lerp(endMarker.position, startMarker.position, alpha);
    }

}
