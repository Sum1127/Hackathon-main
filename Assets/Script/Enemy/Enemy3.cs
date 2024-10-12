using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    Transform playerTr; // プレイヤーのTransform
    Transform enemy3Tr; //enemy3のTransform
    [SerializeField] float speed = 2; // 敵の動くスピード
    private bool isMoving = true;
    [SerializeField] int _power;
    private float hidari;
    private float migi;

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        enemy3Tr = transform;
        StartCoroutine(ToggleMovementRoutine());
        hidari = transform.localScale.x;
        migi = transform.localScale.x * -1;
    }

    private void Update()
    {
        if(isMoving)
        {
            if (Vector2.Distance(transform.position, playerTr.position) < 3f)
                return;

            // プレイヤーに向けて進む
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                speed * Time.deltaTime);
        }

        //アニメーションの向きを変える
        Vector3 localScale = transform.localScale;
        if (playerTr.position.x - enemy3Tr.position.x < 0)
        {
            localScale.x = hidari;
        }

        else if (playerTr.position.x - enemy3Tr.position.x > 0)
        {
            localScale.x = migi;
        }
        transform.localScale = localScale;
    }

    IEnumerator ToggleMovementRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);//0.5秒待つ
            isMoving = !isMoving;  // 状態を反転させる
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().TakeDamage(_power);
        }
    }

}
