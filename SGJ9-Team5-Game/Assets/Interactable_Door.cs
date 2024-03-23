using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Door : InteractableManager
{

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
        print("OnInteract initiated in Interactable_Door");
        // TODO: end the game
    }

    public override string GetHoverText()
    {
        return "逃げる！ [LMB]";
    }
}
