using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class FpvInteractController : MonoBehaviour
{
    [Tooltip("The maximum distance at which you can interact with an object")]
    [SerializeField] private float interactRange = 2f;
    [Tooltip("This is the root from which the raycast starts, i.e. the camera root if you want to interact with the object directly in front of the camera.")]
    [SerializeField] private Transform originTransform;
    [SerializeField] private GameObject hotbarRoot;
    [SerializeField] private GameObject itemIconPrefab;
    private List<GameObject> inventory = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        updateHotbar();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            InteractWith();
        }
    }

    void InteractWith()
    {
        RaycastHit hit;
        if(Physics.Raycast(originTransform.position, originTransform.TransformDirection(Vector3.forward), out hit, interactRange))
        {
            if(hit.transform.gameObject.GetComponent<CollectibleManager>())
            {
                pickup(hit.transform.gameObject);
            }
            // else if an interactable, etcetera, do other stuff?? such as call something on an object to turn off the breaker etc.
        }
    }

    private void pickup(GameObject obj)
    {
        obj.GetComponent<CollectibleManager>().OnCollectByPlayer();
        inventory.Add(obj);
        updateHotbar();
    }

    private void drop(int indexOf)
    {
        inventory[indexOf].GetComponent<CollectibleManager>().OnDropByPlayer(originTransform.position+(originTransform.forward*interactRange/2f));
        inventory.RemoveAt(indexOf);
        updateHotbar();
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
            newIcon.GetComponent<iconGenerator>().Generate(i+1, cm.getDisplayName(), cm.getIcon());
            // modify the icon to show the proper number (i), name, and icon
        }
    }
}
