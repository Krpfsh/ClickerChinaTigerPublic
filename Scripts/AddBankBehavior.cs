using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddBankBehavior : MonoBehaviour
{
    [SerializeField] private Image imageMeat;
    [SerializeField] private TextMeshProUGUI costNumber;

    [SerializeField] private GameObject[] bankObjects;

    private void Awake()
    {
        UpdateUIBank();
        UpdateBankObjects();
    }
    public void AddBank()
    {
        if (DataManager.BankCount == 2 && DataManager.MeatCount >= 300)
        {
            DataManager.BankCount++;
            DataManager.MeatCount -= 300;
            DataManager.SaveBankCount();
            MeatTextManager.UpdateMeatText();
            UpdateBankObjects();
            UpdateUIBank();
        }
        if (DataManager.BankCount == 1 && DataManager.MeatCount >= 150)
        {
            DataManager.BankCount++;
            DataManager.MeatCount -= 150;
            DataManager.SaveBankCount();
            MeatTextManager.UpdateMeatText();
            UpdateBankObjects();
            UpdateUIBank();
        }
    }
    private void UpdateBankObjects()
    {
        for (int i = 0; i < DataManager.BankCount; i++)
        {
            bankObjects[i].SetActive(true);
        }
    }
    private void UpdateUIBank()
    {
        switch (DataManager.BankCount)
        {
            case 1:
                costNumber.text = "150";
                break;
            case 2:
                costNumber.text = "300";
                break;
            case 3:
                imageMeat.enabled = false;
                costNumber.text = "MAX";
                PlayerPrefs.SetInt("AchivementBuyAllBanks", 1);
                break;
            default:
                Debug.LogError("Error");
                break;
        }
    }
}
