using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawnController : MonoBehaviour {


        private void OnTriggerEnter2D(Collider2D other)
        // when a fish hits the despawner, set it as inactive
    {
        if (other.gameObject.CompareTag("fish")) // bug catcher, just to make sure it can't set random other game objects inactive
        {
            other.gameObject.SetActive(false);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
