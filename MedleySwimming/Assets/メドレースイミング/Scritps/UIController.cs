using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MedleySwimming
{
    public class UIController : MonoBehaviour
    {
        [Header("プレイヤー座標")]
        [SerializeField] private Transform playerTransform;
        [Header("オフセット座標")]
        [SerializeField] private Vector3[] offset;
        [Header("キャンバス")]
        [SerializeField] private Canvas canvas;
        [Header("画像のレクトトランスフォーム")]
        [SerializeField] private RectTransform[] imageRectTransform;

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < imageRectTransform.Length; i++)
            {
                //プレイヤーの位置にオフセットを追加
                Vector3 playerPosition = playerTransform.position + offset[i];

                //ワールド座標をスクリーン座標に変換
                Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, playerPosition);

                //スクリーン座標をCanvasの座標に変換
                Vector2 canvasPosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    canvas.GetComponent<RectTransform>(),
                    screenPosition,
                    Camera.main,
                    out canvasPosition);

                //画像のレクトトランスフォームに座標を設定
                imageRectTransform[i].anchoredPosition = canvasPosition;
            }
        }
    }
}