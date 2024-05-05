using Dreamteck.Splines;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddTigerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject tigerPrefab;

    [SerializeField] private Image imageCoin;
    [SerializeField] private TextMeshProUGUI costNumber;

    private int[] costTiger = { 0, 150, 300, 450, 600, 750 };
    private void Awake()
    {
        for (int i = 1; i < PlayerPrefs.GetInt("TigerCount"); i++)
        {
            CreateTiger();
        }
        
        UpdateUITiger();
    }
    private void Start()
    {

        Debug.Log(costTiger.Length + " " + DataManager.TigerCount);


    }
    public void AddTiger()
    {

        if (costTiger.Length >= DataManager.TigerCount)
        {
            if (DataManager.CoinCount > costTiger[DataManager.TigerCount])
            {
                BuyTiger(costTiger[DataManager.TigerCount]);
            }
        }
    }
    private void BuyTiger(int cost)
    {
        DataManager.CoinCount -= cost;
        CoinsTextManager.UpdateCoinsText();

        DataManager.TigerCount++;
        DataManager.SaveTigerCount();
        CreateTiger();
        UpdateUITiger();
    }
    private void CreateTiger()
    {
        GameObject tigerosso = Instantiate(tigerPrefab, Vector3.zero, Quaternion.identity);
        tigerosso.GetComponent<SplineFollower>().followSpeed = Random.Range(10f, 15f);
    }
    private void UpdateUITiger()
    {
        if (costTiger.Length > DataManager.TigerCount)
        {
            costNumber.text = costTiger[DataManager.TigerCount].ToString();
        }
        else
        {
            imageCoin.enabled = false;
            PlayerPrefs.SetInt("AchivementBuyAllTigers", 1);
            costNumber.text = "MAX";
        }
    }
}
