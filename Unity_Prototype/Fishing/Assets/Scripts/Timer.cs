using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour {

    public float RoundTime;

	// Use this for initialization
	void Start () {
		
        
	}
	
	// Update is called once per frame
	void Update () {

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
        }

    }
}
