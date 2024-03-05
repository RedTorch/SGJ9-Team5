using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpv_controller : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5f;
    private Vector3 inputVector = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if(inputVector.magnitude >= 0.1f)
        {
            inputVector = inputVector.normalized;
            Quaternion targetRotation = Quaternion.LookRotation(inputVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 3000f * Time.deltaTime);
            transform.Translate(0f, 0f, Time.deltaTime*5f);
        }
    }
}
