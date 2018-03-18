using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnSpriteController : MonoBehaviour {

    public SpriteRenderer p1bkg, p2bkg;
    public Sprite activeSprite, inactiveSprite;

    public GameObject gamecontroller;
 
    // Use this for initialization
    void Start ()
    {
        p1bkg.sprite = activeSprite;
        p2bkg.sprite = inactiveSprite;

    }
	
	// Update is called once per frame
	void Update ()
    {
        TwoPlayerController controller = gamecontroller.GetComponent<TwoPlayerController>();

        
        if (controller.IsP1Active() == true)
        {
            p1bkg.sprite = activeSprite;
            p2bkg.sprite = inactiveSprite;
        }

        else
        {
            p2bkg.sprite = activeSprite;
            p1bkg.sprite = inactiveSprite;
        }
	}
}
