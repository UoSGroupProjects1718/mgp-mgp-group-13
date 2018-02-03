using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour {

    public float speed, direction;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 tickMove = new Vector3(1 * speed * direction * Time.deltaTime, 0.0f, 0.0f);
        transform.position += tickMove;
	}
}
