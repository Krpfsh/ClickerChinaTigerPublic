using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeBehavior : MonoBehaviour
{
    public void GoldToMeat()
    {
        if(DataManager.CoinCount >= 100)
        {
            DataManager.CoinCount -= 100;
            DataManager.MeatCount += 100;
            CoinsTextManager.UpdateCoinsText();
            MeatTextManager.UpdateMeatText();
        }
    }
    public void MeatToGold()
    {
        if (DataManager.MeatCount >= 100)
        {
            DataManager.CoinCount += 100;
            DataManager.MeatCount -= 100;
            CoinsTextManager.UpdateCoinsText(); 
            MeatTextManager.UpdateMeatText();
        }
    }
    public void GoldMeatToRecordCoin()
    {
        if (DataManager.MeatCount >= 100 && DataManager.CoinCount >=100)
        {
            DataManager.CoinCount -= 100;
            DataManager.MeatCount -= 100;
            DataManager.RecordCoin++;
            DataManager.Save();
            DataManager.SaveRecord();
            CoinsTextManager.UpdateCoinsText();
            MeatTextManager.UpdateMeatText();
            RecordTextManager.UpdateRecordText();
        }
    }
}
