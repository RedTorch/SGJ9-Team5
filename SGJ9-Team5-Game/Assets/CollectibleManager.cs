using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public string displayName = "defaultName";
    [SerializeField] private Sprite icon;
    public int points = 0;
    public int weight = 1; // 1-3 range of; default carry capacity of 4; +2 +4 +6 for each size of pack
    public int shop_price = 0;
    public string shop_description = "REGULAR CUBE:\nI am just a regular cube, no survival utility whatsoever!";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollectByPlayer()
    {
        gameObject.SetActive(false);
        // the addition of this object to the player's inventory is handled by the pickup and drop methods on the player side
    }

    public void OnDropByPlayer(Vector3 dropPosition)
    {
        /* assumes that the object has a rigidbody and will drop with gravity
        if we're not using this approach, we need to raycast and drop the object either at the point of collision,
        or (if out of range) the hit location of a raycast pointed directly down from the first raycast's terminal point */
        gameObject.transform.position = dropPosition;
        gameObject.SetActive(true);
    }

    public Sprite getIcon()
    {
        return icon;
    }

    public string getDisplayName()
    {
        return displayName;
    }
}
