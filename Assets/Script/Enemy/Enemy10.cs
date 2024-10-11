using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy10 : MonoBehaviour
{

    public float speed = 30f; // 移動速度
    private Vector3 direction; // オブジェクトの進行方向
    private float lifetime = 15f; // オブジェクトの寿命
    [SerializeField] int _power;

    void Start()
    {
        // 斜め方向に初期移動方向を設定 (例: 45度の斜め右上)

        direction = new Vector3(1, 1, 0).normalized;

        // 15秒後にオブジェクトを削除
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // 斜めに移動し続ける
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ぶつかったオブジェクトの表面法線を取得
        Vector3 normal = collision.contacts[0].normal;

        // 45度の反射角度を計算（入射角45度の反射）
        direction = Vector3.Reflect(direction, normal).normalized;

        // 移動方向を反射後の方向に更新
        transform.position += direction * speed * Time.deltaTime;

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().TakeDamage(_power);
        }

    }

}
