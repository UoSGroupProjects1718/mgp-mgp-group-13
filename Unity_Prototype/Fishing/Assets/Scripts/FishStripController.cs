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
    public int Reference;
}

public class FishStripController : MonoBehaviour {

    public float SpawnRate;     // set in unity, delay in seconds between spawns
    private float SpawnTick;    // used internally to time the fish
    public GameObject fish;     // set in unity, reference to fish object to spawn  
    public Transform SpawnPoint;// set in unity, reference to location at which fish will spawn
    public int poolLimit;       // set in unity, max size of fishPool
    List<GameObject> fishPool;  // obect pool for fish for this player

    public int Direction = 1;

    public Fish[] FishPrefabs;

    // Use this for initialization
    void Start()
    {
        SpawnTick = SpawnRate;
        
        // temporary object pool populator
        fishPool = new List<GameObject>(); // instantiates the list
                      
        for  (int i = 0; i< poolLimit; i++) // instantiates <poolLimit> number of fish into the list and sets them as inactive
        {
            int randIndex = Random.Range(0, FishPrefabs.Length);
            GameObject obj = (GameObject)Instantiate(fish);
            FishController fishControl = obj.GetComponent<FishController>();
            fishControl.SetupFish(Direction, FishPrefabs[randIndex]);
            obj.SetActive(false);
            fishPool.Add(obj);
        }

    }

    void spawnFish()
    
    // function for spawning fish as they are needed

    {
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
