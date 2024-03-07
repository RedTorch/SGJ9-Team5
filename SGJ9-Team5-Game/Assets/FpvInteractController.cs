using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FpvInteractController : MonoBehaviour
{
    [Tooltip("The maximum distance at which you can interact with an object")]
    [SerializeField] private float interactRange = 2f;
    [Tooltip("This is the root from which the raycast starts, i.e. the camera root if you want to interact with the object directly in front of the camera.")]
    [SerializeField] private Transform originTransform;
    [SerializeField] private GameObject hotbarRoot;
    [SerializeField] private GameObject itemIconPrefab;
    [SerializeField] private TMP_Text weightText;
    [SerializeField] private TMP_Text hoverText;
    [SerializeField] private int defaultCarryingCapacity = 4;
    [SerializeField] private int addedCarryingCapacity = 0;
    private int carryingCapacity = 0;
    private int currCarriedWeight = 0;
    private int selectedSlot = 0;
    private List<GameObject> inventory = new List<GameObject>();
    private bool isFrozen = false;
    // Start is called before the first frame update
    void Start()
    {
        updateHotbar();
        updateWeight();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFrozen)
        {
            return;
        }
        RaycastHit hit;
        hoverText.text = "";
        if(Physics.Raycast(originTransform.position, originTransform.TransformDirection(Vector3.forward), out hit, interactRange))
        {
            InteractWith(hit);
        }
        checkForSelectedSlot();
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(selectedSlot>0)
            {
                drop(selectedSlot-1);
            }
        }
    }
    private void checkForSelectedSlot()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9) && inventory.Count>=10)
        {
            selectedSlot = 10;
            updateHotbar();
            return;
        }
        for (int i = 1; i <= inventory.Count; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                selectedSlot = i;
                updateHotbar();
                return;
            }
        }
    }

    void InteractWith(RaycastHit hit)
    {
        if(hit.transform.gameObject.GetComponent<CollectibleManager>())
        {
            // hoverText: show item properties!!
            hoverText.text = hit.transform.gameObject.GetComponent<CollectibleManager>().GetHoverText();
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                pickup(hit.transform.gameObject);
            }
        }
        // else if an interactable, etcetera, do other stuff?? such as call something on an object to turn off the breaker etc.
        else if(hit.transform.gameObject.GetComponent<InteractableManager>())
        {
            // hoverText
            hoverText.text = hit.transform.gameObject.GetComponent<InteractableManager>().GetHoverText();//"インタラクト[LMB]";
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("interaction initiated");
                hit.transform.gameObject.GetComponent<InteractableManager>().OnInteract();
            }
        }
    }

    private void pickup(GameObject obj)
    {
        if(obj.GetComponent<CollectibleManager>().weight > carryingCapacity - currCarriedWeight)
        {
            // return a failure due to weight limit! maybe flash-red the weight capacity, or display an onscreen message, or both!!
            return;
        }
        obj.GetComponent<CollectibleManager>().OnCollectByPlayer();
        inventory.Add(obj);
        updateHotbar();
        if(inventory.Count==1)
        {
            selectedSlot = 1; 
        }
        updateOnPickupDrop();
    }

    private void drop(int indexOf)
    {
        inventory[indexOf].GetComponent<CollectibleManager>().OnDropByPlayer(originTransform.position+(originTransform.forward*interactRange/2f));
        inventory.RemoveAt(indexOf);
        if(selectedSlot>inventory.Count)
        {
            selectedSlot = inventory.Count;
        }
        updateOnPickupDrop();
    }

    private void updateHotbar()
    {
        // remove all elements in the hotbar
        var children = new List<GameObject>();
        foreach (Transform child in hotbarRoot.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
        // use inventory[] to generate the icons and names of the objects
        for(int i = 0; i < inventory.Count; i++)
        {
            GameObject go = inventory[i];
            CollectibleManager cm = go.GetComponent<CollectibleManager>();
            // Instantiate the icon prefab
            GameObject newIcon = Instantiate(itemIconPrefab, hotbarRoot.transform);
            newIcon.GetComponent<iconGenerator>().Generate(i+1, cm.getDisplayName(), cm.getIcon(), i+1==selectedSlot);
            // modify the icon to show the proper number (i), name, and icon
        }
    }

    private void updateWeight()
    {
        carryingCapacity = defaultCarryingCapacity + addedCarryingCapacity;
        currCarriedWeight = 0;
        foreach(GameObject go in inventory)
        {
            currCarriedWeight += go.GetComponent<CollectibleManager>().weight;
        }
        weightText.text = "重さ" + currCarriedWeight + "/" + carryingCapacity;
    }

    private void updateOnPickupDrop()
    {
        updateHotbar();
        updateWeight();
    }

    public void setFreeze(bool set)
    {
        isFrozen = set;
    }
}
