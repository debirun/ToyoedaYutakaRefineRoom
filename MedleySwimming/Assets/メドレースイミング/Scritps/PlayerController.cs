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
        [Header("速度")]
        [SerializeField] private float swimSpeed = 1f;
        [Header("最大体力")]
        [SerializeField] private float maxHealth = 3f;
        private float health;
        [Header("左端")]
        [SerializeField] private float leftEdge = -7.0f;
        [Header("右端")]
        [SerializeField] private float rightEdge = 7.0f;
        private Vector3 direction = Vector3.left;
        [Header("ゲージ画像")]
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
            //速度は常に減らす。体力は常に増やす
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
            //移動する
            transform.Translate(direction * swimSpeed * Time.deltaTime);

            //左端で方向変換
            if (transform.position.x < leftEdge)
            {
                transform.position = new Vector3(leftEdge, transform.position.y, transform.position.z);
                direction = Vector3.right;

                //入力方法を更新
                inputWorld.NextInputClass();                
            }

            //右端で方向変換
            if (transform.position.x > rightEdge)
            {
                transform.position = new Vector3(rightEdge, transform.position.y, transform.position.z);
                direction = Vector3.left;

                //入力方法を更新
                inputWorld.NextInputClass();
            }
        }

        //速度を上げる
        public void UpSpeed()
        {
            swimSpeed += 0.3f;
        }

        //体力を減らす
        public void DecreaseHealth()
        {
            health -= 0.3f;
        }

        //体力を表示する
        private void DisplayHealth()
        {
            fillAmount = health / maxHealth;
            fillAmount = Mathf.Clamp(fillAmount, 0.0f, 1.0f);
            gaugeImage.fillAmount = fillAmount;
        }
    }
}