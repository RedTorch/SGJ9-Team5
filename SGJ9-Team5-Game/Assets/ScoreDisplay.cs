using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inventoryRoot;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private LevelManager myLm;
    private FpvInteractController myFic;
    // Start is called before the first frame update
    void Start()
    {
        myFic = player.GetComponent<FpvInteractController>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnActivate()
    {
        gameObject.SetActive(true);
        myFic.updateHotbar(inventoryRoot);
        var children = new List<GameObject>();
        foreach (Transform child in inventoryRoot.transform) children.Add(child.gameObject);
        foreach (GameObject child in children)
        {
            child.GetComponent<iconGenerator>().ShowScore();
        }
        scoreText.text = "Score: " + myFic.GetScore();
        myLm.EndGame();
    }
}
