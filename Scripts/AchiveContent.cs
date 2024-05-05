using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class AchiveContent : MonoBehaviour
{
    [SerializeField] private GameObject _achiveContentPrefab;
    [SerializeField] private AchiveItem[] _achiveText;

    private void Awake()
    {
        for (int i = 0; i < _achiveText.Length; i++)
        {
            GameObject achieve = Instantiate(_achiveContentPrefab, gameObject.transform.position, Quaternion.identity);

            achieve.transform.SetParent(gameObject.transform);
            achieve.transform.transform.localScale = Vector3.one;

            
            switch (YandexGame.lang)
            {
                case "ru":
                    achieve.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _achiveText[i].TextRu;
                    break;
                case "en":
                    achieve.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _achiveText[i].TextEng;
                    break;
                case "tr":
                    achieve.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = _achiveText[i].TextTr;
                    break;
            }
            ////achive.GetComponentInChildren<Text>().text = _achiveText[i];

            Debug.Log(_achiveText[i].id);
            Debug.Log(PlayerPrefs.GetInt($"{_achiveText[i].id}"));
            if (PlayerPrefs.GetInt($"{_achiveText[i].id}") >= 1)
            {
                achieve.transform.GetChild(1).GetComponent<Image>().color = Color.yellow;
            }
            else
            {
                achieve.transform.GetChild(1).GetComponent<Image>().color = Color.black;
            }
            if (PlayerPrefs.GetInt("Achivement100tap", 0) < 100 && i == 0)
            {
                achieve.transform.GetChild(1).GetComponent<Image>().color = Color.black;
            }
        }
    }
}
