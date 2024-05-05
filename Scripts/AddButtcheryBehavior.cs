using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddButtcheryBehavior : MonoBehaviour
{
    [SerializeField] private Image imageCoin;
    [SerializeField] private TextMeshProUGUI costNumber;

    [SerializeField] private GameObject[] butcheryObjects;

    private void Awake()
    {
        UpdateUIButchery();
        UpdateButcherObjects();
        CoinsTextManager.UpdateCoinsText();
    }
    public void AddButchery()
    {
        if (DataManager.ButcherCount == 2 && DataManager.CoinCount >= 300)
        {
            DataManager.ButcherCount++;
            DataManager.CoinCount -= 300;
            DataManager.SaveButcherCount();
            CoinsTextManager.UpdateCoinsText();
            UpdateButcherObjects();
            UpdateUIButchery();
        }
        if (DataManager.ButcherCount == 1 && DataManager.CoinCount >= 150)
        {
            DataManager.ButcherCount++;
            DataManager.CoinCount -= 150;
            DataManager.SaveButcherCount();
            CoinsTextManager.UpdateCoinsText();
            UpdateButcherObjects();
            UpdateUIButchery();
        }
    }
    private void UpdateButcherObjects()
    {
        for (int i = 0; i < DataManager.ButcherCount; i++)
        {
            butcheryObjects[i].SetActive(true);
        }
    }
    private void UpdateUIButchery()
    {
        switch (DataManager.ButcherCount)
        {
            case 1:
                costNumber.text = "150";
                break;
            case 2:
                costNumber.text = "300";
                break;
            case 3:
                imageCoin.enabled = false;
                costNumber.text = "MAX";
                PlayerPrefs.SetInt("AchivementBuyAllButchers", 1);
                break;
            default:
                Debug.LogError("Error");
                break;
        }
    }
}
