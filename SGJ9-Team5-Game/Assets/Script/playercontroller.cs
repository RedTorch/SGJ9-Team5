using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercon : MonoBehaviour
{

     public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 入力に基づいて移動方向を計算する
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        // 移動させる
        transform.Translate(movement);
    }
}
