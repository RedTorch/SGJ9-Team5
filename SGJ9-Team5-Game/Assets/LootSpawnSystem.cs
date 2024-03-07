using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawnSystem : MonoBehaviour
{
    [SerializeField] private Transform[] spawnLocations; // give me some bounding cubes, each one has an equal chance of being selected, and then obejcts are randomly horizontally distributed within its bounds at a y-position of 1.5f
    [SerializeField] private List<GameObject> vitalItems;
    private int vitalsToExclude = 3;
    [SerializeField] private GameObject[] junkItems; // spawned at random with equal chance
    [SerializeField] private int amountOfJunk = 10;
    [SerializeField] private ShopManager mySm;
    // Start is called before the first frame update
    void Start()
    {
        SpawnLoot();
        mySm.GenerateShop(vitalItems);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

// we're probably gonna want to hide the loot spawning-in and shop generation etc. with a short countdown that is palyed cohncurrently
    void SpawnLoot()
    {
        while(vitalItems.Count > vitalsToExclude)
        {
            Instantiate(vitalItems[UnityEngine.Random.Range(0,vitalItems.Count-1)],randomLoc(),Quaternion.identity);
            vitalItems.RemoveAt(UnityEngine.Random.Range(0,vitalItems.Count-1));
        }
        for(int i = 0; i < amountOfJunk; i++)
        {
            GameObject iitem = junkItems[UnityEngine.Random.Range(0,junkItems.Length-1)];
            Instantiate(iitem, randomLoc(),Quaternion.identity);
        }
    }

    private Vector3 randomLoc()
    {
        Transform rtrans = spawnLocations[UnityEngine.Random.Range(0,spawnLocations.Length-1)];
        Vector3 retVal = rtrans.position + (Vector3.right*rtrans.localScale.x*UnityEngine.Random.Range(-1f,1f)) + (Vector3.forward*rtrans.localScale.z*UnityEngine.Random.Range(-1f,1f));
        return retVal;
    }
}
