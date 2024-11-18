using MedleySwimming;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MedleySwimming
{
    //InputMethodクラスを継承した子クラスを管理する
    public class InputWorld : MonoBehaviour
    {
        private InputMethod currentInputClass;
        private int currentInputIndex = 0;
        private List<InputMethod> inputMethods = new List<InputMethod>();
        // Start is called before the first frame update
        void Start()
        {
            //******子クラスの実態を作る******
            FirstInput firstInput = new GameObject("firstInput").AddComponent<FirstInput>();
            inputMethods.Add(firstInput);
            SecondInput secondInput = new GameObject("secondInput").AddComponent<SecondInput>();
            inputMethods.Add(secondInput);
            ThirdInput thirdInput = new GameObject("thirdInput").AddComponent<ThirdInput>();
            inputMethods.Add(thirdInput);
            ForceInput forceInput = new GameObject("forceInput").AddComponent<ForceInput>();
            inputMethods.Add(forceInput);
            //********************************

            currentInputClass = inputMethods[currentInputIndex];
        }
        
        //入力方法の表示と入力の受付は常に行う
        void Update()
        {            
            currentInputClass.CheckInput();
            currentInputClass.DisplayUI();
        }
        
        //入力方法を順番に変更するメソッド。PlayerControllerで呼び出し
        public void NextInputClass()
        {
            currentInputIndex++;
            if (currentInputIndex >= inputMethods.Count)
            {
                Debug.Log("GameClear");
            }
            else
            {
                currentInputClass = inputMethods[currentInputIndex % inputMethods.Count];
            }
        }
    }
}