using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy10 : MonoBehaviour
{

    public float speed = 30f; // �ړ����x
    private Vector3 direction; // �I�u�W�F�N�g�̐i�s����
    private float lifetime = 15f; // �I�u�W�F�N�g�̎���
    [SerializeField] int _power;

    void Start()
    {
        // �΂ߕ����ɏ����ړ�������ݒ� (��: 45�x�̎΂߉E��)

        direction = new Vector3(1, 1, 0).normalized;

        // 15�b��ɃI�u�W�F�N�g���폜
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // �΂߂Ɉړ���������
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �Ԃ������I�u�W�F�N�g�̕\�ʖ@�����擾
        Vector3 normal = collision.contacts[0].normal;

        // 45�x�̔��ˊp�x���v�Z�i���ˊp45�x�̔��ˁj
        direction = Vector3.Reflect(direction, normal).normalized;

        // �ړ������𔽎ˌ�̕����ɍX�V
        transform.position += direction * speed * Time.deltaTime;

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().TakeDamage(_power);
        }

    }

}
