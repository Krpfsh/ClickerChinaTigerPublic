using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class RecordTextManager : MonoBehaviour
{
    private static TextMeshProUGUI recordNumberText;
    private void Awake()
    {
        recordNumberText = gameObject.GetComponent<TextMeshProUGUI>();
        UpdateRecordText();
    }
    public static void UpdateRecordText()
    {
        YandexGame.NewLeaderboardScores("LiderBoardCoin", DataManager.RecordCoin);
        recordNumberText.text = DataManager.RecordCoin.ToString();
        if(DataManager.RecordCoin >= 100){
        PlayerPrefs.SetInt("Achivement100RatingCoins", 1);
        }
    }
}
