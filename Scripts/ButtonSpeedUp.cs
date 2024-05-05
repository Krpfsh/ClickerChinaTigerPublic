using System.Collections;
using TMPro;
using UnityEngine;
using Dreamteck.Splines;

public class ButtonSpeedUp : MonoBehaviour
{
    private float speedBoostDuration = 0f;
    [SerializeField] private TextMeshProUGUI textBonus;
    [SerializeField] private GameObject VFX; //confetti

    public void ButtonClick()
    {
        PlayerPrefs.SetInt("Achivement100tap", PlayerPrefs.GetInt("Achivement100tap", 0)+1);
        speedBoostDuration += 2f;
        if (speedBoostDuration > 0f && speedBoostDuration < 50f)
        {
            TigerSpeedUp(12f);
            textBonus.text = "x1.2";
        }
        else if (speedBoostDuration >= 50f && speedBoostDuration < 200f)
        {
            TigerSpeedUp(15f);
            textBonus.text = "x1.5";
        }
        else if (speedBoostDuration >= 200f)
        {
            TigerSpeedUp(20f);
            textBonus.text = "x2";
            PlayerPrefs.SetInt("AchivementMaxSpeed", 1);
        }
        VFX.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(DisableSpeedBoost());
    }

    private void TigerSpeedUp(float speed)
    {
        GameObject[] tiger = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < tiger.Length; i++)
        {
            tiger[i].GetComponent<SplineFollower>().followSpeed =speed;
        }
           
    }

    IEnumerator DisableSpeedBoost()
    {
        yield return new WaitForSeconds(3f);
        VFX.SetActive(false);
        speedBoostDuration = 0f;
        TigerSpeedUp(10f);
        textBonus.text = "x1";
    }
}
