using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerupButtonController : MonoBehaviour {
    public GameObject p1JellyButton, p1SpeedButton, p2JellyButton, p2SpeedButton;
    public GameObject PowerupController;
    private powerUpJelly jellyController;
    private powerUpSpeed speedController;

    private Button p1jellyB, p1speedB, p2jellyB, p2speedB;

    // Use this for initialization
    void Start ()
    {
        Button p1jellyB = p1JellyButton.GetComponent<Button>();
        Button p1speedB = p1SpeedButton.GetComponent<Button>();
        Button p2jellyB = p2JellyButton.GetComponent<Button>();
        Button p2speedB = p2SpeedButton.GetComponent<Button>();

        powerUpJelly jellyController = PowerupController.GetComponent<powerUpJelly>();
        powerUpSpeed speedController = PowerupController.GetComponent<powerUpSpeed>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (jellyController.p1Ready == true) p1jellyB.interactable = true;
        else p1jellyB.interactable = false;

        if (jellyController.p2Ready) p2jellyB.interactable = true;
        else p2jellyB.interactable = false;

        if (speedController.p1Ready) p1speedB.interactable = true;
        else p1speedB.interactable = false;

        if (jellyController.p2Ready) p2speedB.interactable = true;
        else p2speedB.interactable = false;


    }
}
