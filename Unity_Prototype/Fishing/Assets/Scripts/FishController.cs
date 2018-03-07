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
    private TwoPlayerController PlayerRef;

  
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
        PlayerRef = controller.GetComponent<TwoPlayerController>();
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 tickMove = new Vector3(1 * speed * direction * Time.deltaTime, 0.0f, 0.0f);
        transform.position += tickMove;
        if (touching == true) //basic check, need to incorperate lineMoving from player controller  GetComponent<TwoPlayerController>().lineMoving == true)
        {
            CatchFish(Info);
            if (Input.GetButton("Fire1"))
            {
                gameObject.SetActive(false); //set fish inactive if input if pressed while fish is colliding
                PlayerRef.addScore(PlayerID, Info.ScoreValue);
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
        if (PlayerRef.lineMoving == false)
        {
            if (fish.Name == "JellyFish")
            {
                PlayerRef.addScore(PlayerID, fish.ScoreValue);
                PlayerRef.lineMoving = true;
                if (PlayerRef.lineDown == true)
                {
                    PlayerRef.upFrame();
                }
                else
                {
                    PlayerRef.downFrame();
                }
                touching = false;
            }
        }
    }
}


// catch fish function
// takes GameObject (Fish) as an input
// sets an animation state in the player char
// sets the line moving in the opposite direction
// scores the correct player
// removes the fish from the active pool.

