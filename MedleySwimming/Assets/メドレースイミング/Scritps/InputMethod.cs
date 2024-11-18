using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MedleySwimming
{
    public abstract class InputMethod : MonoBehaviour
    {
        public TextMeshProUGUI inputUIText;
        public string inputUI;

        //初期化（子クラスで呼び出し）
        public void Init(string inputUI)
        {
            inputUIText = FindObjectOfType<TextMeshProUGUI>();            
            this.inputUI = inputUI;
        }

        //クリアしたときに子クラスで呼び出し
        public void ClearInput()
        {            
            MedleySwimming.PlayerController.instance.UpSpeed();            
            MedleySwimming.PlayerController.instance.DecreaseHealth();
        }

        //プレイヤーの入力を受け付ける。子クラスによって違う方法
        public abstract void CheckInput();

        //プレイヤーの上に入力方法を表示。子クラスによって違う
        public abstract void DisplayUI();
    }
}