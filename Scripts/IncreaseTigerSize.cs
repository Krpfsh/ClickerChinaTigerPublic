using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseTigerSize : MonoBehaviour
{
    [SerializeField] private Image imageCoin;
    [SerializeField] private TextMeshProUGUI costNumber;

    private void Start()
    {
        UpdateUIIncreaseTigerSize();
        IncreaseSizeTiger();
        //MeatTextManager.UpdateMeatText();
    }
    public void BuyIncreaseSizeTiger()
    {
        Debug.Log(PlayerPrefs.GetFloat("TigerSize"));
        if (DataManager.TigerSize == 1f && DataManager.MeatCount >= 1000)
        {
            DataManager.TigerSize += 0.5f;
            DataManager.MeatCount -= 1000;
            DataManager.SaveSizeTiger();
            MeatTextManager.UpdateMeatText();
            IncreaseSizeTiger();
            UpdateUIIncreaseTigerSize();
        }
        if (DataManager.TigerSize == 0.5f && DataManager.MeatCount >= 500)
        {
            DataManager.TigerSize += 0.5f;
            DataManager.MeatCount -= 500;
            DataManager.SaveSizeTiger();
            MeatTextManager.UpdateMeatText();
            IncreaseSizeTiger();
            UpdateUIIncreaseTigerSize();
        }
    }

    private void IncreaseSizeTiger()
    {
        for (int i = 0; i < DataManager.TigerCount; i++)
        {
            GameObject.FindGameObjectsWithTag("Player")[i].transform.localScale = new Vector3(DataManager.TigerSize, DataManager.TigerSize, DataManager.TigerSize);
        }
    }
    private void UpdateUIIncreaseTigerSize()
    {
        switch (DataManager.TigerSize)
        {
            case 0.5f:
                costNumber.text = "500";
                break;
            case 1f:
                costNumber.text = "1000";
                break;
            case 1.5f:
                imageCoin.enabled = false;
                costNumber.text = "MAX";
                PlayerPrefs.SetInt("AchivementBuyAllTigerSize", 1);
                break;
            default:
                Debug.LogError("Error");
                break;
        }
    }
}
