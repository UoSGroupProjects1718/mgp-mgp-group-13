using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour {

    public float speed; // direction and speed are split for ease of balence, direction should always be 1 or -1
    private int direction;

    private Fish Info;
    private SpriteRenderer SprRen;
    public int PlayerID;

    private GameObject controller;
    private TwoPlayerController PlayerCont;

    private GameObject buttonControl;
    private powerupButtonController buttonController;


  
    private bool touching;

    public void SetupFish(int dir, Fish info, int PlayerRef)
    {
        //assign variables for the fish
        SprRen = GetComponent<SpriteRenderer>();
        Info = info; //information from the fish prefab (score)
        direction = dir; 
        SprRen.sprite = Info.FishSprite;
        PlayerID = PlayerRef;

    }

	// Use this for initialization
	void Start () {
        SprRen = GetComponent<SpriteRenderer>();

        //get other game objects and their components for reference
        controller = GameObject.Find("PlayerController");        
        PlayerCont = controller.GetComponent<TwoPlayerController>();
        buttonControl = GameObject.Find("PowerUpsController");
        buttonController = buttonControl.GetComponent<powerupButtonController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (PlayerID == 1) //if the fish belongs to player one, transform along the bottom strip (left to right)
        {
            Vector3 tickMove = new Vector3((speed * direction * Time.deltaTime * TwoPlayerController.fishBonusSpeedP1), 0.0f, 0.0f); // added fishBonusSpeed and removed magic number '1' AM
            transform.position += tickMove;

        }

        if (PlayerID == 2) //if the fish belongs to player one, transform along the top strip (right to left)
        {
            Vector3 tickMove = new Vector3((speed * direction * Time.deltaTime * TwoPlayerController.fishBonusSpeedP2), 0.0f, 0.0f); // added fishBonusSpeed and removed magic number '1' AM
            transform.position += tickMove;

        }



        if (touching == true) //basic check, need to incorperate lineMoving from player controller  GetComponent<TwoPlayerController>().lineMoving == true)
        {
            CatchFish(Info);
            if ((PlayerCont.P1ButtonDown == true && PlayerCont.lineDown == true) || (PlayerCont.P2ButtonDown == true && PlayerCont.lineDown == false) && PlayerCont.lineMoving == false)
            {
                gameObject.SetActive(false); //set fish inactive if input if pressed while fish is colliding
                PlayerCont.addScore(PlayerID, Info.ScoreValue);
            }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        touching = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        touching = false;
    }

    void CatchFish(Fish fish) //when fish collide with the line check if it's a special fish
    {
        if (PlayerCont.lineMoving == false)
        {
            if (fish.Name == "JellyFish") //if the fish is a jellyfish, add a negative score and 
            {
                PlayerCont.addScore(PlayerID, fish.ScoreValue);
                PlayerCont.lineMoving = true;

                touching = false;
            }
        }

        if (fish.Name == "jellyPickup")
        {
            if (PlayerID == 1)
            {
                powerUpJelly.p1Ready = true;
                buttonController.p1Jelly.interactable = true;
            }
            else
            {
                powerUpJelly.p2Ready = true;
                buttonController.p2Jelly.interactable = true;
            }
            touching = false;
        }

        if (fish.Name == "speedPickup")
        {
            if (PlayerID == 1)
            {
                powerUpSpeed.p1Ready = true;
                buttonController.p1Speed.interactable = true;
            }
            else
            {
                powerUpSpeed.p2Ready = true;
                buttonController.p2Speed.interactable = true;
            }
            PlayerCont.addScore(PlayerID, fish.ScoreValue);
            touching = false;
        }

    }
}




