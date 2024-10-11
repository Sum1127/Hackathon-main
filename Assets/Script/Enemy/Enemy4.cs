using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    Transform playerTr; // プレイヤーのTransform
    [SerializeField] float speed = 4; // 敵の動くスピード
    [SerializeField] GameObject Player;
    public float time = 0;
    [SerializeField] int _power;
    [SerializeField] GameObject Attacktype;
    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 3)
        {
            Vector2 pos = playerTr.position;
            Instantiate(Attacktype, this.transform.position, Quaternion.identity);
            time = 0;
        }

        // プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector2.Distance(transform.position, playerTr.position) < 15f)
            return;

        // プレイヤーに向けて進む
        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().TakeDamage(_power);
        }
    }

}
