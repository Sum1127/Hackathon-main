using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : MonoBehaviour
{
    public float horizontalSpeed = 5f;  // 水平方向の移動速度
    public float verticalAmplitude = 10f;  // 上下移動の幅（振幅）
    public float verticalFrequency = 5f;  // 上下移動の速度（周波数）

    private Vector3 startPosition;  // オブジェクトの初期位置を保存

    void Start()
    {
        // オブジェクトの初期位置を保存
        startPosition = transform.position;
    }

    void Update()
    {
        // 水平方向に一定速度で移動
        transform.position += Vector3.left * horizontalSpeed * Time.deltaTime;

        // 上下移動の計算
        float verticalOffset = Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude;

        // 上下移動を加味した新しい位置を設定
        transform.position = new Vector3(transform.position.x, startPosition.y + verticalOffset, transform.position.z);
    }
}
