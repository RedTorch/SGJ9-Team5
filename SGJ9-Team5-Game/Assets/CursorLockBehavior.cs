using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockBehavior : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLock(bool b)
    {
        if(b)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.gameObject.GetComponent<FPController>().setFreeze(true);
            player.gameObject.GetComponent<FpvInteractController>().setFreeze(true);
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            player.gameObject.GetComponent<FPController>().setFreeze(false);
            player.gameObject.GetComponent<FpvInteractController>().setFreeze(false);
        }
    }
}
