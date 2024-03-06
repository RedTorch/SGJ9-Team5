using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class eventmaneger : MonoBehaviour
{   
    float time1;
    float time2;
    private float timer;

    float Emergency;

    private bool a = true;
    private bool b = false;
    public NewBehaviourScript quake;


    // Start is called before the first frame update
    void Start()
    {
        ResetTimers();
        Emergency =Random.Range(0,3);
        Debug.Log("event"+Emergency);
        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // 経過時間を追加

        if (a)
        {
            Countdown1(); 
        }

        if (b)
        {
            Countdown2(); 
        }
    }

    void ResetTimers()
    {
        timer = 0f;
        time1 = Random.Range(5.0f, 10.0f);
        time2 = Random.Range(0f, 10.0f);
    }

    void Countdown1()
    {
        time1 -= Time.deltaTime;
        if (time1 <= 0)
        {
            a = false;
            b = true;
            ResetTimers();
        GameObject earth = GameObject.Find("Cube (1)");
        quake = earth.GetComponent<NewBehaviourScript>(); 
        quake.start = true;
        }
        Debug.Log("準備残り時間: " + time1); // 現在の残り時間をコンソールに表示
    }

    void Countdown2()
    {
        time2 -= Time.deltaTime;
        if (time2 <= 0)
        {
            b = false;
        }
        Debug.Log("エスケープ残り時間: " + time2); // 現在の残り時間をコンソールに表示
    }
}