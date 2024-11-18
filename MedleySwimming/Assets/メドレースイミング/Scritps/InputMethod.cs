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

        //�������i�q�N���X�ŌĂяo���j
        public void Init(string inputUI)
        {
            inputUIText = FindObjectOfType<TextMeshProUGUI>();            
            this.inputUI = inputUI;
        }

        //�N���A�����Ƃ��Ɏq�N���X�ŌĂяo��
        public void ClearInput()
        {            
            MedleySwimming.PlayerController.instance.UpSpeed();            
            MedleySwimming.PlayerController.instance.DecreaseHealth();
        }

        //�v���C���[�̓��͂��󂯕t����B�q�N���X�ɂ���ĈႤ���@
        public abstract void CheckInput();

        //�v���C���[�̏�ɓ��͕��@��\���B�q�N���X�ɂ���ĈႤ
        public abstract void DisplayUI();
    }
}