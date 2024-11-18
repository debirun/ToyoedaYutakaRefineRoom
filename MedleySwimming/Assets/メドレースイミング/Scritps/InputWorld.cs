using MedleySwimming;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MedleySwimming
{
    //InputMethod�N���X���p�������q�N���X���Ǘ�����
    public class InputWorld : MonoBehaviour
    {
        private InputMethod currentInputClass;
        private int currentInputIndex = 0;
        private List<InputMethod> inputMethods = new List<InputMethod>();
        // Start is called before the first frame update
        void Start()
        {
            //******�q�N���X�̎��Ԃ����******
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
        
        //���͕��@�̕\���Ɠ��͂̎�t�͏�ɍs��
        void Update()
        {            
            currentInputClass.CheckInput();
            currentInputClass.DisplayUI();
        }
        
        //���͕��@�����ԂɕύX���郁�\�b�h�BPlayerController�ŌĂяo��
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