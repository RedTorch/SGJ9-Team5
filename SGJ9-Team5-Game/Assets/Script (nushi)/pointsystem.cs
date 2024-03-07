using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsystem : MonoBehaviour
{
    private int totalScore = 0;
    private int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{ 
   

}

private void OnTriggerEnter(Collider other)
    {
        Debug.Log("衝突" );
        // 衝突したものがアイテムであるかチェック
        if (other.CompareTag("Item"))
        {
            // アイテムの名前を確認
            string itemName = other.gameObject.name;

            // アイテムの名前に応じてスコアを加算
            if (itemName == "1")
            {
                // スコアを加算して表示する
                score++;
                Debug.Log("Score: " + score);
            }
 
    }
    }
}