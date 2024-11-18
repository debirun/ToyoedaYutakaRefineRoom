using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player�̃{�^�����͂��󂯕t����
//�ŏ��̓��͂��玞�Ԃ��v��A���Ԃ������狭���I�ɃJ�E���g���O�ɂ���
//GageController�ō�������\�b�h�ɂ�count�𑗂�
public class PlayerController : MonoBehaviour
{
    private int inputCount = 0;
    [Header("��������")]
    [SerializeField] private float timeLimit = 5.0f;
    private float timer = 0.0f;

    private bool startedInput;    

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inputCount);

        InputCheck();        
        
        //�^�C�}�[�N��
        if(startedInput)
        {
            timer += Time.deltaTime;

            //�^�C�����~�b�g�ŃJ�E���g���Z�b�g
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

            //�i���Z�b�g��j�ŏ��̓��͂�������
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
