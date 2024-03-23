using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class iconGenerator : MonoBehaviour
{
    [SerializeField] private TMP_Text number;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private UnityEngine.UI.Image iconImage;
    [SerializeField] private UnityEngine.UI.Image highlightImage;
    [SerializeField] private GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate(int newNumber, string newName, Sprite newIcon, bool isHighlighted, int scoreVal)
    {
        number.text = newNumber.ToString();
        itemName.text = newName;
        iconImage.sprite = newIcon;
        highlightImage.enabled = isHighlighted;
        if(scoreVal>0)
        {
            scoreText.GetComponent<TMP_Text>().text = "+"+scoreVal;
        }
        else if(scoreVal<0)
        {
            scoreText.GetComponent<TMP_Text>().text = ""+scoreVal;
        }
        else
        {
            scoreText.GetComponent<TMP_Text>().text = "0";
        }
    }
    public void ShowScore()
    {
        scoreText.SetActive(true);
    }
}
