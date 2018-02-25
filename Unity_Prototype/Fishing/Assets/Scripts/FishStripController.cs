using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// There is one of these controllers on each fish strip.
/// holds its own object pool for fish (fishPool)
/// handles its own deactivation of disused fish, keeps them inside its list.

[System.Serializable]
public class Fish
    // defines a fish as having a name, a sprite and a reference
{
    public string Name;
    public Sprite FishSprite;
    public int ScoreValue;
}

public class FishStripController : MonoBehaviour {

    public float SpawnRate;     // set in unity, delay in seconds between spawns
    private float SpawnTick;    // used internally to time the fish
    public GameObject fish;     // set in unity, reference to fish object to spawn  
    public Transform SpawnPoint;// set in unity, reference to location at which fish will spawn
    public int poolLimit;       // set in unity, max size of fishPool
    List<GameObject> fishPool;  // obect pool for fish for this player
    public int playerRef;
    public int Direction;

    public Fish[] SpawnData;  // array for data population of fish


    public void ShuffleFish(List<GameObject> fishPool) // fisher-yates shuffle function takes a list of gameobjects fishPool as an input and shuffles it
    {
        
        for (int i = 0; i < fishPool.Count; i++)
        {
            GameObject temp = fishPool[i];
            int randomIndex = Random.Range(i, fishPool.Count);
            fishPool[i] = fishPool[randomIndex];
            fishPool[randomIndex] = temp;
        }
        
    }


    void Start()
    {

        SpawnTick = SpawnRate;


        // OBJECT POOL
        // Balance Solution 1:
        // game spawns 100 fish in the object pool for each player
        // they are generated with a percentage chance of being each fish
        // they are given to the player randomly
        // the player would never be able to catch all avalible fish in the pool so randomisation is based on what gets pulled
        //
        //
        // Balance Solution 2:
        // game spawns small (10 ish) fish pools which operate as above
        // once each player has caught a fish, both players get given an identical fish from a shared object pool
        //
        //
        //Balance Solutionn 1:
        fishPool = new List<GameObject>(); // instantiates the list
                      
        for  (int i = 0; i< 3; i++) // instantiates <poolLimit> number of fish into the list and sets them as inactive
        {
            // int randIndex = Random.Range(0, SpawnData.Length);

            GameObject obj = (GameObject)Instantiate(fish);
            FishController fishControl = obj.GetComponent<FishController>();
            fishControl.SetupFish(Direction, SpawnData[0],playerRef); 
            obj.SetActive(false);
            fishPool.Add(obj);
        }

        for (int i = 0; i < 5; i++) // instantiates <poolLimit> number of fish into the list and sets them as inactive
        {
     
            GameObject obj = (GameObject)Instantiate(fish);
            FishController fishControl = obj.GetComponent<FishController>();
            fishControl.SetupFish(Direction, SpawnData[1], playerRef);
            obj.SetActive(false);
            fishPool.Add(obj);
        }


        for (int i = 0; i < 1; i++) // instantiates <poolLimit> number of fish into the list and sets them as inactive
        {
            
            GameObject obj = (GameObject)Instantiate(fish);
            FishController fishControl = obj.GetComponent<FishController>();
            fishControl.SetupFish(Direction, SpawnData[2], playerRef);
            obj.SetActive(false);
            fishPool.Add(obj);
        }


        for (int i = 0; i < 1; i++) // instantiates <poolLimit> number of fish into the list and sets them as inactive
        {
           
            GameObject obj = (GameObject)Instantiate(fish);
            FishController fishControl = obj.GetComponent<FishController>();
            fishControl.SetupFish(Direction, SpawnData[3], playerRef);
            obj.SetActive(false);
            fishPool.Add(obj);
        }





    }

    void spawnFish()
    
    // function for activating fish as they are needed

    {
        ShuffleFish(fishPool);

        for (int i = 0; i < fishPool.Count; i++) //loops through the pool
        {
            if(!fishPool[i].activeInHierarchy)  // checks the fish isn't already in use
            {
                fishPool[i].transform.position = SpawnPoint.position;   
                fishPool[i].transform.rotation = SpawnPoint.rotation;
                fishPool[i].SetActive(true);    //moves it to the correct location and rotation then activates it
                break;                          //only does this for the first fish it finds
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // counts down
        if (SpawnTick > 0)
        {
            SpawnTick -= Time.deltaTime;
        }

        else if (SpawnTick <= 0) // when counter reaches zero call spawnfish function and reset the timer
        {
            spawnFish();
            SpawnTick = SpawnRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
        // when a fish hits the despawner, set it as inactive
    {
        if (other.gameObject.CompareTag("fish")) // bug catcher, just to make sure it can't set random other game objects inactive
        {
            other.gameObject.SetActive(false);
        }
    }
}
