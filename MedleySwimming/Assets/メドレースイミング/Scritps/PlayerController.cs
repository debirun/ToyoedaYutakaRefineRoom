using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MedleySwimming
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;
        [Header("InputWorld")]
        [SerializeField] private InputWorld inputWorld;
        [Header("���x")]
        [SerializeField] private float swimSpeed = 1f;
        [Header("�ő�̗�")]
        [SerializeField] private float maxHealth = 3f;
        private float health;
        [Header("���[")]
        [SerializeField] private float leftEdge = -7.0f;
        [Header("�E�[")]
        [SerializeField] private float rightEdge = 7.0f;
        private Vector3 direction = Vector3.left;
        [Header("�Q�[�W�摜")]
        [SerializeField] private Image gaugeImage;
        private float fillAmount = 1f;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            health = maxHealth;
        }
        private void Update()
        {            
            //���x�͏�Ɍ��炷�B�̗͂͏�ɑ��₷
            swimSpeed -= Time.deltaTime;
            if(swimSpeed < 1.0f)
            {
                swimSpeed = 1.0f;
            }
            health += Time.deltaTime;
            if(health > 3.0f)
            {
                health = 3.0f;
            }            

            Move();            

            DisplayHealth();
        }
        public void Move()
        {
            //�ړ�����
            transform.Translate(direction * swimSpeed * Time.deltaTime);

            //���[�ŕ����ϊ�
            if (transform.position.x < leftEdge)
            {
                transform.position = new Vector3(leftEdge, transform.position.y, transform.position.z);
                direction = Vector3.right;

                //���͕��@���X�V
                inputWorld.NextInputClass();                
            }

            //�E�[�ŕ����ϊ�
            if (transform.position.x > rightEdge)
            {
                transform.position = new Vector3(rightEdge, transform.position.y, transform.position.z);
                direction = Vector3.left;

                //���͕��@���X�V
                inputWorld.NextInputClass();
            }
        }

        //���x���グ��
        public void UpSpeed()
        {
            swimSpeed += 0.3f;
        }

        //�̗͂����炷
        public void DecreaseHealth()
        {
            health -= 0.3f;
        }

        //�̗͂�\������
        private void DisplayHealth()
        {
            fillAmount = health / maxHealth;
            fillAmount = Mathf.Clamp(fillAmount, 0.0f, 1.0f);
            gaugeImage.fillAmount = fillAmount;
        }
    }
}