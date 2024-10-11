using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    Transform playerTr; // プレイヤーのTransform
    Transform enemy1Tr; //enemy1のTransform
    [SerializeField] float speed = 2; // 敵の動くスピード
    [SerializeField] int _power;
    private float hidari;
    private float migi;

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        enemy1Tr = transform;
        //アニメーションの右向きと左向き
        hidari = transform.localScale.x;
        migi = transform.localScale.x * -1;
    }

    private void Update()
    {

        // プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            return;

        // プレイヤーに向けて進む
        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);

        //アニメーションの向きを変える
        Vector3 localScale = transform.localScale;
        if (playerTr.position.x - enemy1Tr.position.x < 0)
        {
            localScale.x = hidari;
        }

        else if (playerTr.position.x - enemy1Tr.position.x > 0)
        {
            localScale.x = migi;
        }
        transform.localScale = localScale;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().TakeDamage(_power);
        }
    }

}
