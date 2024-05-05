using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAwakeStopTime : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void Awake()
    {
        Time.timeScale = 0f;
    }
}
