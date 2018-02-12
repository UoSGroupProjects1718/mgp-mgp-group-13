using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour {

    public float speed, direction; // direction and speed are split for ease of balence, direction should always be 1 or -1
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 tickMove = new Vector3(1 * speed * direction * Time.deltaTime, 0.0f, 0.0f);
        transform.position += tickMove;
	}
}
