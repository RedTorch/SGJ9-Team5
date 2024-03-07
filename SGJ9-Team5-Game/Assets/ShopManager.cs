using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private RectTransform shopItemListRoot;
    [SerializeField] private GameObject shopButtonPrefab;
    [SerializeField] private TMP_Text descText;
    [SerializeField] private TMP_Text buyText;
    [SerializeField] private Transform player;
    private List<GameObject> goods = new List<GameObject>();
    private List<TMP_Text> buttonLabels = new List<TMP_Text>();
    [SerializeField] private GameObject[] junkItems;
    [SerializeField] private GameObject[] usefulItems;
    [SerializeField] private List<GameObject> testList = new List<GameObject>();

    [SerializeField] private int money = 10000;
    private float chanceOfGettingUseful = 0.4f;
    private int maxShopItems = 8;
    private int currSelectedItemIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        GenerateShop(testList); //in actual game, GenerateShop will be called externally by the class that scatters objects, so that the leftovers can be sold in the shop
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void OnShopEnter()
    {
        gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.gameObject.GetComponent<FPController>().setFreeze(true);
        player.gameObject.GetComponent<FpvInteractController>().setFreeze(true);
    }

    public void OnShopExit()
    {
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.gameObject.GetComponent<FPController>().setFreeze(false);
        player.gameObject.GetComponent<FpvInteractController>().setFreeze(false);
    }

    public void OnItemSelect(int indexOfItem) // called by individual sold item buttons
    {
        // TODO: prevent selection if the item is sold out; display message
        if(goods[indexOfItem]==null)
        {
            currSelectedItemIndex = -1;
            return;
        }
        descText.text = goods[indexOfItem].GetComponent<CollectibleManager>().shop_description;
        buyText.text = "買う - " + goods[indexOfItem].GetComponent<CollectibleManager>().shop_price + "";
        currSelectedItemIndex = indexOfItem;
    }
    
    public void OnSelectedItemBuy() // called by the "buy" button, but only valid when an item is selected
    {
        if(currSelectedItemIndex==-1 || goods[currSelectedItemIndex]==null) // OR u dont have enough money u broke mfer
        {
            // play the womp womp sound
            currSelectedItemIndex = -1;
            return;
        }
        // play kaching sound
        // subtract the moneys
        // instantiate gameObject
        Instantiate(goods[currSelectedItemIndex],player.position+(player.forward*1f),Quaternion.identity);
        // set status to bought-- cannot be bought again
        goods[currSelectedItemIndex] = null;
        buttonLabels[currSelectedItemIndex].text = "<<< 売り切れ >>>";
        currSelectedItemIndex = -1;
    }

    public void GenerateShop(List<GameObject> gos)
    {
        // generate a "goods" list mixing useful and useless items
        List<GameObject> shopItems = new List<GameObject>();
        foreach(GameObject go in gos)
        {
            shopItems.Add(go);
        }
        int remainingSpaces = maxShopItems - gos.Count;
        if(remainingSpaces>0)
        {
            int usefulSize = usefulItems.Length;
            int uselessSize = junkItems.Length;
            for(int i = 0; i < remainingSpaces; i++)
            {
                if(UnityEngine.Random.value<chanceOfGettingUseful)
                {
                    shopItems.Add(usefulItems[(int)Mathf.Clamp(Mathf.Floor((UnityEngine.Random.Range(0f,1f*usefulSize))),0,usefulSize-1)]);
                }
                else
                {
                    shopItems.Add(junkItems[(int)Mathf.Clamp(Mathf.Floor(UnityEngine.Random.Range(0f,1f*uselessSize)),0,uselessSize-1)]);
                }
            }
        }
        else
        {
            print("error: remaining vital items exceeds max shop spaces. Excess will be removed at random.");
        }
        // clear all children of the goods list root before adding new labels!
        var children = new List<GameObject>();
        foreach (Transform child in shopItemListRoot.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
        // generate buttons for each element in the "goods" List
        int limit = shopItems.Count;
        for(int i = 0; i < limit; i++)
        {
            // add object to goods
            int randomInt = (int)(Mathf.Floor(UnityEngine.Random.Range(0f,1f*shopItems.Count)));
            goods.Add(shopItems[randomInt]);
            /* instantiate new shop item UI element as child of shopItemListRoot
            and add the label to buttonLabels List */
            GameObject newButton = Instantiate(shopButtonPrefab, shopItemListRoot);
            buttonLabels.Add(newButton.GetComponent<ButtonHandler>().myLabel);
            /* call onInstan in ButtonHandler to pass on this shop handler component
            and a reference to the GameObject that it represents (so it can get the info*/
            newButton.GetComponent<ButtonHandler>().onInstan(this.GetComponent<ShopManager>(), shopItems[randomInt], i);
            // delete shopItems[randomInt] from shopItems
            shopItems.RemoveAt(randomInt);
        }
    }
}