using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private float levelTime = 0f;
    private float earthquakeTime = 0f;
    [SerializeField] private float earthquakeBaseTime = 40f;
    [SerializeField] private float earthquakeVariance = 20f;
    private float collapseTime = 0f;
    [SerializeField] private float collapseBaseTime = 5f;
    [SerializeField] private float collapseVariance = 15f;
    [SerializeField] private EarthquakeOnTimer myEot;
    private bool isActive = true; // set false if the game is completed successfully and you want to stop the earthquake action from progressing

    // we should develop a system to allow this to be set from an inter-scene data object (so you can select difficulty from main menu, ubnlock harder difficulties, etc.)
    private bool earthquakeOccurred = false;
    // Start is called before the first frame update
    void Start()
    {
        earthquakeTime = earthquakeBaseTime + UnityEngine.Random.Range(0f,earthquakeVariance);
        collapseTime = earthquakeTime + collapseBaseTime + UnityEngine.Random.Range(0f,collapseVariance);
        print("levelmanager: earthquake at " + earthquakeTime + "s, collapse at " + collapseTime + "s.");
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            return;
        }
        levelTime += Time.deltaTime;
        if(!earthquakeOccurred)
        {
            if(levelTime >= earthquakeTime)
            {
                earthquakeOccurred = true;
                myEot.StartShake(collapseTime-earthquakeTime+2f, 5f, 0.25f);
                // TODO: call earthquake from script; earthquake should continue indefinitely
                // the earthquake script should also handle environmental events, e.g. call methods on objects to cause them to break or become hazards-- doors don't open, etc.
            }
        }
        else // i.e. if earthquake is happening
        {
            if(levelTime >= collapseTime)
            {
                int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(sceneIndex);
                // TODO: call gameOver (cut to black, "you took too long!" message is displayed; try again OR return to menu from here)
            }
        }
    }
}