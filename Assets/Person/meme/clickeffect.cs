using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickeffect : MonoBehaviour
{
    public GameObject clickeffectPrefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//左クリック検知
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 9.0f;//カメラとの距離を設定
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Instantiate(clickeffectPrefab, worldPosition, Quaternion.identity);
        }
    }
}
