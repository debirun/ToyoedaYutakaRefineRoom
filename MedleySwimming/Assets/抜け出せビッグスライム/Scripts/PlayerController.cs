using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Playerのボタン入力を受け付ける
//最初の入力から時間を計り、時間が来たら強制的にカウントを０にする
//GageControllerで作ったメソッドににcountを送る
public class PlayerController : MonoBehaviour
{
    private int inputCount = 0;
    [Header("制限時間")]
    [SerializeField] private float timeLimit = 5.0f;
    private float timer = 0.0f;

    private bool startedInput;    

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inputCount);

        InputCheck();        
        
        //タイマー起動
        if(startedInput)
        {
            timer += Time.deltaTime;

            //タイムリミットでカウントリセット
            if(timer > timeLimit)
            {
                ResetCount();                
            }
        }        
    }

    private void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inputCount++;
            GaugeController.instance.ApplyGauge(inputCount);

            //（リセット後）最初の入力だったら
            if (!startedInput)
            {
                startedInput = true;
            }
        }
    }
    private void ResetCount()
    {
        startedInput = false;
        inputCount = 0;
        timer = 0.0f;
        GaugeController.instance.ApplyGauge(inputCount);
    }
}
