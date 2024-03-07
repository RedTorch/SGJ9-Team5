using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Laptop : InteractableManager
{
    [SerializeField] private ShopManager mySman;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnInteract()
    {
        print("OnInteract initiated in Interactable_Laptop");
        mySman.OnShopEnter();
    }

    public override string GetHoverText()
    {
        return "PCを使う[LMB]";
    }
}
