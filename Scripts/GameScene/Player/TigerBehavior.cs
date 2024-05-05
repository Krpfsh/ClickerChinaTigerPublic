using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TigerBehavior : MonoBehaviour
{
    private int _bankReward = 5;
    private int _butcherReward = 7;
    //[SerializeField] private RewardManager coinAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bank"))
        {
            DataManager.CoinCount += _bankReward;
            CoinsTextManager.UpdateCoinsText();
            DataManager.Save();
            //coinAnim.RewardPileOfCoin(10);
        }
        if (other.gameObject.CompareTag("Butcher"))
        {
            DataManager.MeatCount += _butcherReward;
            MeatTextManager.UpdateMeatText();
            DataManager.Save();
            //coinAnim.RewardPileOfCoin(10);
        }
    }
}
