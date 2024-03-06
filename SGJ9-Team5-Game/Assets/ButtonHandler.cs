using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private ShopManager mysm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onInstan(GameObject parentCaller)
    {
        mysm = parentCaller.GetComponent<ShopManager>();
    }
}
