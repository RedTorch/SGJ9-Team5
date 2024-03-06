using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testdoor : MonoBehaviour
{
    public float detectionRadius = 5f; // 検出する半径
    private Animator anim = null;
   public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーとの距離を計算
        float distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);

        // プレイヤーとの距離が検出半径以内にあるかどうかを確認
        if (distanceToPlayer <= detectionRadius)
        {
            // プレイヤーが近くにいる場合の処理をここに記述
            Debug.Log("プレイヤーが近くにいます！");
            anim.SetBool("Open", true);
        }
        else
        {
            anim.SetBool("Open", false);
        }
    }
}
