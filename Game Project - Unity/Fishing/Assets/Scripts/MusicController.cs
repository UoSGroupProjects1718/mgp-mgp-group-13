using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject); //prevents MusicPlayer game object from being destroyed so that the waves music is played consistently throughout each scene 
	}
}
