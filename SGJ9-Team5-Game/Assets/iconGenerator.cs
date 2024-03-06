using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Microsoft.Unity.VisualStudio.Editor;

public class iconGenerator : MonoBehaviour
{
    [SerializeField] private TMP_Text number;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private UnityEngine.UI.Image iconImage;
    [SerializeField] private UnityEngine.UI.Image highlightImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate(int newNumber, string newName, Sprite newIcon, bool isHighlighted)
    {
        number.text = newNumber.ToString();
        itemName.text = newName;
        iconImage.sprite = newIcon;
        highlightImage.enabled = isHighlighted;
    }
}
