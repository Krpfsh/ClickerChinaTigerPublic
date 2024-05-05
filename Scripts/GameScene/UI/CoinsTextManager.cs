using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsTextManager : MonoBehaviour
{
    private static TextMeshProUGUI coinsNumberText;
    private void Awake()
    {
        coinsNumberText = gameObject.GetComponent<TextMeshProUGUI>();
        UpdateCoinsText();
    }
    public static void UpdateCoinsText()
    {
        coinsNumberText.text = DataManager.CoinCount.ToString();
        if (DataManager.CoinCount >= 10000)
        {
            PlayerPrefs.SetInt("Achivement10000Gold", 1);
        }
    }
}
