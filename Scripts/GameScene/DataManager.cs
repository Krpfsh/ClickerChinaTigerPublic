using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static int CoinCount;
    public static int MeatCount;
    public static int BankCount;
    public static int ButcherCount;
    public static int TigerCount;
    public static int RecordCoin;
    public static float TigerSize;
    private void Awake()
    {
        CoinCount = PlayerPrefs.GetInt("CoinCount", 10000);
        MeatCount = PlayerPrefs.GetInt("MeatCount", 0);

        BankCount = PlayerPrefs.GetInt("BankCount", 1);
        ButcherCount = PlayerPrefs.GetInt("ButcherCount", 1);

        TigerCount = PlayerPrefs.GetInt("TigerCount", 1);
        RecordCoin = PlayerPrefs.GetInt("Record", 0);

        TigerSize = PlayerPrefs.GetFloat("TigerSize", 0.5f);
    }
    public static void Save()
    {
        PlayerPrefs.SetInt("MeatCount", MeatCount);
        PlayerPrefs.SetInt("CoinCount", CoinCount);
    }
    public static void SaveButcherCount()
    {
        PlayerPrefs.SetInt("ButcherCount", ButcherCount);
    }
    public static void SaveBankCount()
    {
        PlayerPrefs.SetInt("BankCount", BankCount);
    }
    public static void SaveTigerCount()
    {
        PlayerPrefs.SetInt("TigerCount", TigerCount);
    }
    public static void SaveRecord()
    {
        PlayerPrefs.SetInt("Record", RecordCoin);
    }
    public static void SaveSizeTiger()
    {
        PlayerPrefs.SetFloat("TigerSize", TigerSize);
    }
}
