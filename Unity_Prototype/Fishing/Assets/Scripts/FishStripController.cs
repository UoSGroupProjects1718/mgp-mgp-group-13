using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStripController : MonoBehaviour {

    public float SpawnRate;
    private float SpawnTick;
    public GameObject fish;
    public Transform SpawnPoint;
    
    // Use this for initialization
    void Start()
    {
        SpawnTick = SpawnRate;
    }

    // Update is called once per frame
    void Update()
    {

        if (SpawnTick > 0)
        {
            SpawnTick -= Time.deltaTime;
        }

        else if (SpawnTick <= 0)
        {
            Instantiate(fish, SpawnPoint);
            SpawnTick = SpawnRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fish"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
