using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    Transform playerTr; // プレイヤーのTransform
    [SerializeField] float speed = 2; // 敵の動くスピード
    private bool isMoving = true;

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(ToggleMovementRoutine());
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
    }

    IEnumerator ToggleMovementRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);//0.5秒待つ
            isMoving = !isMoving;  // 状態を反転させる
        }
    }

}
