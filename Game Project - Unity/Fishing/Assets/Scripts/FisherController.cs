using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherController : MonoBehaviour {

    public int id;

	// Use this for initialization
	void Start ()
    {
        id = GetComponentInParent<FishStripController>().playerRef;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
