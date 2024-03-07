using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawnSystem : MonoBehaviour
{
    [SerializeField] private Vector3[] SpawnLocations;
    [SerializeField] private GameObject[] vitalItems;
    [SerializeField] private GameObject[] junkItems; // spawned at random with equal chance
    [SerializeField] private float amountOf
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

// we're probably gonna want to hide the loot spawning-in and shop generation etc. with a short countdown that is palyed cohncurrently
    void SpawnLoot()
    {
        //
    }
}
