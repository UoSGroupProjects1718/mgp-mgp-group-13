using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour {

    public float speed; // direction and speed are split for ease of balence, direction should always be 1 or -1
    private int direction;

    private Fish Info;
    private SpriteRenderer SprRen;

    private bool touching;

    public void SetupFish(int dir, Fish info)
    {
        SprRen = GetComponent<SpriteRenderer>();
        Info = info;
        direction = dir;
        SprRen.sprite = Info.FishSprite;
    }

	// Use this for initialization
	void Start () {
        SprRen = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 tickMove = new Vector3(1 * speed * direction * Time.deltaTime, 0.0f, 0.0f);
        transform.position += tickMove;
	}

    private void OnEnable()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("Enter");
        touching = true;
        if (touching)
        {
            if (collision.gameObject.CompareTag("line"))
            {
                if (Input.GetButton("Fire1"))
                {
                    gameObject.SetActive(false);
                }

            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        print("Exit");
        touching = false;
    }
}
