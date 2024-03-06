using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float speed = 5f;
    private int plus = 50;
     private int minus = -30;

    int totalscore=0;
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

    private void OnCollisionEnter(Collision other)
    {
       // Debug.Log("あ" );
        // 衝突したものがアイテムであるかチェック
            string itemName = other.gameObject.name;

            // アイテムの名前に応じてスコアを加算
            if (itemName == "1")
            {
                // スコアを加算して表示する
                totalscore += plus;
                Debug.Log("Score: " + totalscore);
            }

             if (itemName == "2")
            {
                // スコアを加算して表示する
                totalscore += minus;
                Debug.Log("Score: " + totalscore);
            }


        




 
    }
}

