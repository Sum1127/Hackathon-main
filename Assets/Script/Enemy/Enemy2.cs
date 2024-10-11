using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2: MonoBehaviour
{
    Transform playerTr; // プレイヤーのTransform
    Transform enemy2Tr; //enemy2のTransform
    [SerializeField] float speed = 4; // 敵の動くスピード
    [SerializeField] int _power;
    private float hidari;
    private float migi;

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        enemy2Tr = transform;
        hidari = transform.localScale.x;
        migi = transform.localScale.x * -1;
    }



    private void Update()
    {

        // プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector2.Distance(transform.position, playerTr.position) < 3f)
            return;

        // プレイヤーに向けて進む
        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);

        //アニメーションの向きを変える
        Vector3 localScale = transform.localScale;
        if (playerTr.position.x - enemy2Tr.position.x > 0)
        {
            localScale.x = hidari;
        }

        else if (playerTr.position.x - enemy2Tr.position.x < 0)
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
