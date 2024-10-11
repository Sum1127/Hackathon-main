using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHp = 500;    // 最大HP
    private int currentHp;     // 現在のHP

    // HPを初期化するメソッド
    void Start()
    {
        InitHP(maxHp);
    }

    public void InitHP(int hp)
    {
        maxHp = hp;
        currentHp = maxHp;
    }

    // ダメージを受けるメソッド
    public void TakeDamage(int damage)
    {
        currentHp -= damage;  // HPを減らす
        //Debug.Log(gameObject.name + " は " + damage + " のダメージを受けた。残りHP: " + currentHp);

        // HPが0以下になったら倒される
        if (currentHp == 0)
        {
            Die();
        }
    }

    // 倒されたときの処理
    void Die()
    {
        Debug.Log(gameObject.name + " は倒された。");
        // オブジェクトを消滅させる  // オブジェクトを消滅
    }
}
