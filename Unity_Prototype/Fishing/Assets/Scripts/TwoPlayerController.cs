using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoPlayerController : MonoBehaviour {

    public GameObject P1Line, P2Line; // references to each players line objects
    public float P1_yMin, P1_yMax, speed; // set in unity, tweakable limits for movement of lines.
    public bool lineDown = true, lineMoving, inputClicked; // used internally to animate lines.
    public static int P1Score, P2Score;
    public static float fishBonusSpeedP1, fishBonusSpeedP2;

    private bool p1gLate, p2gLate;
      
    //public Text scoreP1;
    //public Text scoreP2;

    public Button P1Button;
    public Button P2Button;

    [Header("P1 Tally")]
    public Image P1tally1;
    public Image P1tally2;
    public Image P1tally3;
    public Image P1tally4;
    public Image P1tally5;
    public Image P1tally6;

    [Header("P2 Tally")]
    public Image P2tally1;
    public Image P2tally2;
    public Image P2tally3;
    public Image P2tally4;
    public Image P2tally5;
    public Image P2tally6;

    public List<Image> P1tallyList = new List<Image>();
    public List<Image> P2tallyList = new List<Image>();

    public Sprite ui_tally_00;
    public Sprite ui_tally_01;
    public Sprite ui_tally_02;
    public Sprite ui_tally_03;
    public Sprite ui_tally_04;
    public Sprite ui_tally_05;

    public bool P1ButtonDown, P2ButtonDown;
    

    // Use this for initialization
    void Start()
    {
        P1Score = 0; 
        P2Score = 0;
        fishBonusSpeedP1 = 1;
        fishBonusSpeedP2 = 1;

        lineDown = true; // makes sure that the line is in its starting position
        lineMoving = false;
        //scoreP1.text = P1Score.ToString();
        //scoreP2.text = P2Score.ToString();

        Button P1Input = P1Button.GetComponent<Button>();
        Button P2Input = P2Button.GetComponent<Button>();

        P1tallyList.Add(P1tally1);
        P1tallyList.Add(P1tally2);
        P1tallyList.Add(P1tally3);
        P1tallyList.Add(P1tally4);
        P1tallyList.Add(P1tally5);
        P1tallyList.Add(P1tally6);

        P2tallyList.Add(P2tally1);
        P2tallyList.Add(P2tally2);
        P2tallyList.Add(P2tally3);
        P2tallyList.Add(P2tally4);
        P2tallyList.Add(P2tally5);
        P2tallyList.Add(P2tally6);

        foreach (Image tally in P1tallyList) {
            tally.sprite = ui_tally_00;
        }

        foreach (Image tally in P2tallyList) {
            tally.sprite = ui_tally_00;
        }
    }

    private void Update() 
    {
        if (Input.GetKey(KeyCode.LeftControl)) ButtonPressed(P1Button);
        if (Input.GetKey(KeyCode.RightControl)) ButtonPressed(P2Button);
    }
    // Update is called once per frame
    void LateUpdate()
    {   
        
        if (lineMoving == (true) && lineDown == false)  // if the line is already moving and its last complete position was up
        {
            downFrame();                                // animate a down frame
            
        }

        if (lineMoving == (true) && lineDown == true)   // if the line is already moving and its last complete position was down
        {   
            upFrame();                                  // animate an up frame
            
        }

        if (p1gLate) { P1Go(); p1gLate = false; }
        if (p2gLate) { P2Go(); p2gLate = false; }

        //print("Player 1: " + P1ButtonDown.ToString());
        //print("Player 2: " + P2ButtonDown.ToString());

    }

    public bool IsP1Active()
    {
        return lineDown;
        
    }

    // define functions for animating frames of line movement
    public void downFrame()
    {
        if (P1Line.transform.position.y > P1_yMin)  // check the lines arent beyond the limits (only check once using P1's line positions as they will always move in perfect syncronisation and prevent logic conflicts
        {
            P1Line.transform.position += new Vector3(0.0f, -0.1f * speed * Time.deltaTime, 0.0f);   
            P2Line.transform.position += new Vector3(0.0f, -0.1f * speed * Time.deltaTime, 0.0f);
        }
        if (P1Line.transform.position.y <= P1_yMin) // when the lines meet the limits flip the line positon and stop the line moving
        {
            lineDown = true;
            lineMoving = false;
            //P1ButtonDown = false;
            //P2ButtonDown = false;
        }

    }

    public void upFrame()
    {
        if (P1Line.transform.position.y < P1_yMax) // as above
        {
            P1Line.transform.position += new Vector3(0.0f, 0.1f * speed * Time.deltaTime, 0.0f);
            P2Line.transform.position += new Vector3(0.0f, 0.1f * speed * Time.deltaTime, 0.0f);
        }
        if (P1Line.transform.position.y >= P1_yMax) // as above
        {
            lineDown = false;
            lineMoving = false;
            //P1ButtonDown = false;
            //P2ButtonDown = false;
        }
    }

    public void addScore(int PlayerRef, int scoreValue)
    {
        fishBonusSpeedP1 = 1; // whenever a fish is caught it should also end any bonus powerups
        fishBonusSpeedP2 = 1;
        if (PlayerRef == 1)
        {
            P1Score += scoreValue;
            //scoreP1.text = P1Score.ToString();
            CalculateScore(P1Score, 1);

        }
        if (PlayerRef == 2)
        {
            P2Score += scoreValue;
            //scoreP2.text = P2Score.ToString();
            CalculateScore(P2Score, 2);
        }

        //print("Player1: " + P1Score.ToString());
        //print("Player2: " + P2Score.ToString());
    }

    public void ButtonPressed(Button PushedButton)
    {
        if (PushedButton.name == "P1Input")
        {
            P1ButtonDown = true;
            p1gLate = true;
            StartCoroutine(timerToReset());
        }
        else if (PushedButton.name == "P2Input")
        {
            P2ButtonDown = true;
            p2gLate = true;

            StartCoroutine(timerToReset());
        }
    }

    //coroutine for powerup time
    public IEnumerator timerToReset() {
        yield return new WaitForSeconds(0.1f);
        resetButtons();
    }

    void resetButtons() 
    {
        P1ButtonDown = false;
        P2ButtonDown = false;
    }

    public void P2Go()
    {
        if (lineMoving == false && lineDown == false) // the player taps, the line isn't already moving and its current position is up
        {
            lineMoving = true;  // set the line as moving
            downFrame();  // animate a frame of downward movement
        }
          
    }

    public void P1Go()
    {
        if (lineMoving == false && lineDown == true) // the player taps, the line isn't already moving and its current position is down
        {
            lineMoving = true;  //set the line as moving
            upFrame();          // animate a frame of upward movement
        }
    }

    public void CalculateScore(int score, int playerRef)
    {
        //calculate the division and modulo of the score
        int div = score / 5;
        print("DIV: ===" + div.ToString());
        int mod = score % 5;
        print("MOD: ===" + mod.ToString());

        if (playerRef == 1)
        {
            //assign all "tally sprites" to be blank/ a checkmark for now
            foreach (Image tally in P1tallyList)
            {
                tally.sprite = ui_tally_00;
            }

            //using the division, calculate and switch the number of sprites that need to be the full 5 bar tally sprite
            for (int i = 0; i < div; i++)
            {
                P1tallyList[i].sprite = ui_tally_05;
            }
            //change the first sprite after the last full tally to show the modulus
            for (int i = 0; i < 6; i++)
            {
                if (P1tallyList[i].sprite != ui_tally_05)
                {
                    if (mod == 0) P1tallyList[i].sprite = ui_tally_00;
                    if (mod == 1) P1tallyList[i].sprite = ui_tally_01;
                    if (mod == 2) P1tallyList[i].sprite = ui_tally_02;
                    if (mod == 3) P1tallyList[i].sprite = ui_tally_03;
                    if (mod == 4) P1tallyList[i].sprite = ui_tally_04;
                    break;
                }

            }
        }
        //same again for the other player
        else
        {
            foreach (Image tally in P2tallyList)
            {
                tally.sprite = ui_tally_00;
            }

            for (int i = 0; i < div; i++)
            {
                P2tallyList[i].sprite = ui_tally_05;
            }
            for (int i = 0; i < 6; i++)
            {
                if (P2tallyList[i].sprite != ui_tally_05)
                {
                    if (mod == 0) P2tallyList[i].sprite = ui_tally_00;
                    if (mod == 1) P2tallyList[i].sprite = ui_tally_01;
                    if (mod == 2) P2tallyList[i].sprite = ui_tally_02;
                    if (mod == 3) P2tallyList[i].sprite = ui_tally_03;
                    if (mod == 4) P2tallyList[i].sprite = ui_tally_04;
                    break;
                }

            }
        }
    }
}
