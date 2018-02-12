using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetButton("Fire1") && collision.gameObject.CompareTag("fish"))
        {
            GameObject hitFish = (collision.gameObject);
            hitFish.SetActive(false);
        }
    }
}
