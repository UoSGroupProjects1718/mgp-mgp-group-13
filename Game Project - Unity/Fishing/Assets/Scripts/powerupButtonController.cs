using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerupButtonController : MonoBehaviour {
    public Button p1Jelly;
    public Button p2Jelly;
    public Button p1Speed;
    public Button p2Speed;


    // Use this for initialization
    void Start ()
    {
        p1Jelly.interactable = false;
        p2Jelly.interactable = false;
        p1Speed.interactable = false;
        p2Speed.interactable = false;

    }
	
	// Update is called once per frame
	void Update ()
    {


    }
}
