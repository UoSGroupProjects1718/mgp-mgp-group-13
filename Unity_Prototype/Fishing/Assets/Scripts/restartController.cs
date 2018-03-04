using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restartController : MonoBehaviour {

    public Toggle  p1, p2;
    
    public void p1Ready()
    {
    //    p1 = true;
    }

    public void p2Ready()
    {
      //  p2 = true;
    }

    // Use this for initialization
    void Start ()
    {

        //p1 = false;
        //p2 = false;
            

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (p1.isOn == true & p2.isOn == true)
        {
            SceneManager.LoadScene("main", LoadSceneMode.Single);
        }
        
	}
}
