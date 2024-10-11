using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHp = 500;    // �ő�HP
    private int currentHp;     // ���݂�HP

    // HP�����������郁�\�b�h
    void Start()
    {
        InitHP(maxHp);
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
        if (currentHp == 0)
        {
            Die();
        }
    }

    // �|���ꂽ�Ƃ��̏���
    void Die()
    {
        Debug.Log(gameObject.name + " �͓|���ꂽ�B");
        // �I�u�W�F�N�g�����ł�����  // �I�u�W�F�N�g������
    }
}
