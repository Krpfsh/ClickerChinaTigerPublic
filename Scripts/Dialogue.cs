using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private string[] lines = new string[3];
    // Привет! Добро пожаловать в наши восточные земли! Мы ТИГРЫ - бандиты, которые время от времени посещают местные деревни и отбирают мясо и монеты у жестоких местных жителей.
    //О! Тигр! Ты снова приехал в нашу деревню!
    //Не слушайте их! Отправляйтесь с нами в рейд!
    public float textSpeed;

    private int index;
    [SerializeField] private Image basicImage;
    [SerializeField] private Sprite[] images;

    private void Start()
    {
        switch (YandexGame.lang)
        {
            case "ru":
                lines[0] = "Привет! Добро пожаловать в наши восточные земли! Мы ТИГРЫ - бандиты, которые время от времени посещают местные деревни и отбирают мясо и монеты у жестоких местных жителей.";
                lines[1] = "О! Тигр! Ты снова приехал в нашу деревню!";
                lines[2] = "Не слушайте их! Отправляйтесь с нами в рейд!";
                break;
            case "en":
                lines[0] = "Hello! Welcome to our Eastern lands! We are TIGROS - bandits who occasionally visit local villages and take meat and coins from the cruel locals.";
                lines[1] = "Oh! Tigros! You've come to our village again!";
                lines[2] = "Don't listen to them! Come with us on a raid!";
                break;
            case "tr":
                lines[0] = "Merhaba! Doğu topraklarımıza hoş geldiniz! Biz zaman zaman yerel köyleri ziyaret eden, zalim yerlilerden et ve madeni para alan haydut kaplanlarıyız.";
                lines[1] = "Oh! Kaplan! Yine köyümüze geldin!";
                lines[2] = "Onları dinlemeyin! Bizimle baskına çıkın!";
                break;
            default:
                Debug.Log("error");
                break;
        }
        for (int i = 0; i < lines.Length; i++)
        {
            Debug.Log(lines[i]);
        }
        textComponent.text = string.Empty;
        StartDialogue();

    }

    public void ButtonBehavior()
    {
        if(textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }
    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            basicImage.sprite = images[index];
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
