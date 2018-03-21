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


  
    private bool touching;

    public void SetupFish(int dir, Fish info, int PlayerRef)
    {
        SprRen = GetComponent<SpriteRenderer>();
        Info = info;
        direction = dir;
        SprRen.sprite = Info.FishSprite;
        PlayerID = PlayerRef;

    }

	// Use this for initialization
	void Start () {
        SprRen = GetComponent<SpriteRenderer>();

        controller = GameObject.Find("PlayerController");
        PlayerCont = controller.GetComponent<TwoPlayerController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (PlayerID == 1)
        {
            Vector3 tickMove = new Vector3((speed * direction * Time.deltaTime * TwoPlayerController.fishBonusSpeedP1), 0.0f, 0.0f); // added fishBonusSpeed and removed magic number '1' AM
            transform.position += tickMove;

        }

        if (PlayerID == 2)
        {
            Vector3 tickMove = new Vector3((speed * direction * Time.deltaTime * TwoPlayerController.fishBonusSpeedP2), 0.0f, 0.0f); // added fishBonusSpeed and removed magic number '1' AM
            transform.position += tickMove;

        }



        if (touching == true) //basic check, need to incorperate lineMoving from player controller  GetComponent<TwoPlayerController>().lineMoving == true)
        {
            CatchFish(Info);
            if ((PlayerCont.P1ButtonDown == true || PlayerCont.P2ButtonDown == true || Input.GetButton("Fire1")) && PlayerCont.lineMoving == false)
            {
                gameObject.SetActive(false); //set fish inactive if input if pressed while fish is colliding
                PlayerCont.addScore(PlayerID, Info.ScoreValue);
            }
        }
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        touching = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        touching = false;
    }

    void CatchFish(Fish fish)
    {
        if (PlayerCont.lineMoving == false)
        {
            if (fish.Name == "JellyFish")
            {
                PlayerCont.addScore(PlayerID, fish.ScoreValue);
                PlayerCont.lineMoving = true;
                touching = false;
            }
        }

        if (fish.Name == "jellyPickup")
        {
            if (PlayerID == 1) powerUpJelly.p1Ready = true;
            else powerUpJelly.p2Ready = true;

            touching = false;
        }

        if (fish.Name == "speedPickup")
        {
            if (PlayerID == 1) powerUpSpeed.p1Ready = true;
            else powerUpSpeed.p2Ready = true;

            PlayerCont.addScore(PlayerID, fish.ScoreValue);
            touching = false;
        }

    }
}




