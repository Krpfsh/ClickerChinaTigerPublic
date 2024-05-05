using DG.Tweening;
using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private GameObject pileOfCoinParent;
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private Vector3[] initialPos;
    [SerializeField] private Quaternion[] initialRotation;
    [SerializeField] private int CoinNo;

    private void Start()
    {
        initialPos = new Vector3[CoinNo];
        initialRotation = new Quaternion[CoinNo];
        for (int i = 0; i < pileOfCoinParent.transform.childCount; i++)
        {
            initialPos[i] = pileOfCoinParent.transform.GetChild(i).position;
            initialRotation[i] = pileOfCoinParent.transform.GetChild(i).rotation;
        }
    }
    private void Reset()
    {
        for (int i = 0; i < pileOfCoinParent.transform.childCount; i++)
        {
            pileOfCoinParent.transform.GetChild(i).position = initialPos[i];
            pileOfCoinParent.transform.GetChild(i).rotation = initialRotation[i];
        }
    }

    public void RewardPileOfCoin(int No_coin)
    {
        Reset();
        var delay = 0f;
        pileOfCoinParent.SetActive(true);

        for (int i = 0;i <pileOfCoinParent.transform.childCount; i++)
        {
            pileOfCoinParent.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            pileOfCoinParent.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(318f, 800f), 1f).SetDelay(delay+0.5f).SetEase(Ease.OutBack);

            pileOfCoinParent.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay+1f).SetEase(Ease.OutBack);

            delay += 0.2f;
        }
    }
}
