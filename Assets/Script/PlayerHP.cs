using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        if (currentHp <= 0)
        {
            Die();
        }
    }

    // 倒されたときの処理
    void Die()
    {

        Debug.Log(gameObject.name + " は倒された。");
        GetComponent<PlayerInput>().enabled = false;
        FindObjectOfType<GameManager>()._ShowGameOverUI();
        // オブジェクトを消滅させる  // オブジェクトを消滅
    }

    public void _SetMaxHP(int para)
    {
        maxHp += para;
    }

    public void _SetHP(int para)
    {
        currentHp += para;
        if(currentHp>=maxHp)currentHp = maxHp;
    }
    public int GetCurrentHP()
    {
        return currentHp;
    }
}
