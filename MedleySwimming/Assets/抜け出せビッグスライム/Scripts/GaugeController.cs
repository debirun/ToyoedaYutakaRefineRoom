using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    public static GaugeController instance;

    [Header("ゲージ画像")]
    [SerializeField] private Image gaugeImage;
    [Header("ゲージ最大カウント")]
    [SerializeField] private int maxGaugeCount = 50;

    private float fillAmount = 0f;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    

    public void ApplyGauge(int count)
    {
        fillAmount = (float)count / maxGaugeCount;
        fillAmount = Mathf.Clamp(fillAmount, 0f, 1f);
        gaugeImage.fillAmount = fillAmount;
        if(gaugeImage.fillAmount >= 1.0f)
        {
            Debug.Log("GameClear");
        }
    }
}
