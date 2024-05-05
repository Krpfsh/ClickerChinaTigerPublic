using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeatTextManager : MonoBehaviour
{
    private static TextMeshProUGUI meatNumberText;
    private void Awake()
    {
        meatNumberText =  gameObject.GetComponent<TextMeshProUGUI>();
        UpdateMeatText();
    }
    public static void UpdateMeatText()
    {
        meatNumberText.text = DataManager.MeatCount.ToString();
        if(DataManager.MeatCount >= 10000)
        {
            PlayerPrefs.SetInt("Achivement10000Meat", 1);
        }
    }
}
