using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public AudioClip buttonPress;
	public AudioSource audio;

	/*DontDestroyOnLoad(this.gameObject) prevents the LevelManager game object from being destroyed between scenes
		public void LoadLevel() { //applied to UI buttons so that they send a debug message to console and the "main" scene is loaded when clicked
        Debug.Log("Level load requested for : ");
        int c = SceneManager.GetActiveScene().buildIndex;
        if (c < SceneManager.sceneCountInBuildSettings)
	        SceneManager.LoadScene("main");
			DontDestroyOnLoad(this.gameObject); 
	}*/

	public void LoadInstructions() { //applied to "how to play" button so that a debug message is sent to the console and the "Instructions" scene is loaded when clicked 
		Debug.Log("Loading instructions screens");
        	SceneManager.LoadScene("Instructions");
        	DontDestroyOnLoad(this.gameObject);
	}

	public void LoadReadyUp() { //applied to UI buttons so that the "Ready Up" scene is loaded when clicked
        Debug.Log("Level load requested for : ");
        int c = SceneManager.GetActiveScene().buildIndex;
        if (c < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene("Ready_Up");
            DontDestroyOnLoad(this.gameObject);
	}

	public void QuitRequest (string name) { //applied to quit button so that a debug message is sent to the console and the application is closed when clicked 
		Debug.Log("Quit request - I want to quit!");
		DontDestroyOnLoad(this.gameObject);
		Application.Quit(); 
	}

	public void playClip() { //applied to UI buttons so that they play the sound "buttonClick" when clicked
		audio = GetComponent<AudioSource>();
		audio.PlayOneShot(buttonPress);
	}
}
	
	

