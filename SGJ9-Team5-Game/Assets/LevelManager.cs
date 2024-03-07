using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private float levelTime = 0f;
    private float earthquakeTime = 0f;
    [SerializeField] private float earthquakeBaseTime = 40f;
    [SerializeField] private float earthquakeVariance = 20f;
    private float collapseTime = 0f;
    [SerializeField] private float collapseBaseTime = 5f;
    [SerializeField] private float collapseVariance = 15f;

    // we should develop a system to allow this to be set from an inter-scene data object (so you can select difficulty from main menu, ubnlock harder difficulties, etc.)
    private bool earthquakeOccurred = false;
    // Start is called before the first frame update
    void Start()
    {
        earthquakeTime = earthquakeBaseTime + UnityEngine.Random.Range(0f,earthquakeVariance);
        collapseTime = collapseBaseTime + UnityEngine.Random.Range(0f,collapseVariance);
    }

    // Update is called once per frame
    void Update()
    {
        levelTime += Time.deltaTime;
        if(!earthquakeOccurred && levelTime > earthquakeTime)
        {
            // call earthquake
        }
    }
}