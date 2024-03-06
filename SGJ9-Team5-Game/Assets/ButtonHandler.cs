using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonHandler : MonoBehaviour
{
    private ShopManager mysm;
    public TMP_Text myLabel;
    private int indexOfLinkedObj;
    private string labelText = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onInstan(ShopManager parentShopManager, GameObject linkedItem, int newIndexOfLinkedObj)
    {
        mysm = parentShopManager;
        labelText = linkedItem.GetComponent<CollectibleManager>().displayName + " -- " + linkedItem.GetComponent<CollectibleManager>().shop_price + "円";
        myLabel.text = labelText;
        indexOfLinkedObj =  newIndexOfLinkedObj;
    }

    public void OnPressedCall()
    {
        // play a oneshot sound or something
        mysm.OnItemSelect(indexOfLinkedObj);
    }
}
