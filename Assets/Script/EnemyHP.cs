using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int maxHp = 100;    // �ő�HP
    private int currentHp;     // ���݂�HP

    private GameObject _LevelManager;
    private LevelManager _levelManager;
    private GameManager _gameManager;

    // HP�����������郁�\�b�h
    void Start()
    {
        InitHP(maxHp);
        _LevelManager = FindObjectOfType<LevelManager>().gameObject;
        _levelManager = _LevelManager.GetComponent<LevelManager>();
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    public void InitHP(int hp)
    {
        maxHp = hp;
        currentHp = maxHp;
    }

    // �_���[�W���󂯂郁�\�b�h
    public void TakeDamage(int damage)
    {
        currentHp -= damage;  // HP�����炷
        //Debug.Log(gameObject.name + " �� " + damage + " �̃_���[�W���󂯂��B�c��HP: " + currentHp);
        // HP��0�ȉ��ɂȂ�����|�����
        if (currentHp <= 0)
        {
            Die();
        }
    }

    // �|���ꂽ�Ƃ��̏���
    void Die()
    {
        //Debug.Log(gameObject.name + " �͓|���ꂽ�B");
        // �I�u�W�F�N�g�����ł�����
        _gameManager._AddKnockOutAmount();
        _levelManager._DefeatEnemy();
        Destroy(gameObject);  // �I�u�W�F�N�g������
    }
}
