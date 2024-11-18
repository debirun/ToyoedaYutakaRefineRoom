using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MedleySwimming
{
    public class UIController : MonoBehaviour
    {
        [Header("�v���C���[���W")]
        [SerializeField] private Transform playerTransform;
        [Header("�I�t�Z�b�g���W")]
        [SerializeField] private Vector3[] offset;
        [Header("�L�����o�X")]
        [SerializeField] private Canvas canvas;
        [Header("�摜�̃��N�g�g�����X�t�H�[��")]
        [SerializeField] private RectTransform[] imageRectTransform;

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < imageRectTransform.Length; i++)
            {
                //�v���C���[�̈ʒu�ɃI�t�Z�b�g��ǉ�
                Vector3 playerPosition = playerTransform.position + offset[i];

                //���[���h���W���X�N���[�����W�ɕϊ�
                Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, playerPosition);

                //�X�N���[�����W��Canvas�̍��W�ɕϊ�
                Vector2 canvasPosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    canvas.GetComponent<RectTransform>(),
                    screenPosition,
                    Camera.main,
                    out canvasPosition);

                //�摜�̃��N�g�g�����X�t�H�[���ɍ��W��ݒ�
                imageRectTransform[i].anchoredPosition = canvasPosition;
            }
        }
    }
}