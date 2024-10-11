using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    Transform playerTr; // �v���C���[��Transform
    Transform enemy1Tr; //enemy1��Transform
    [SerializeField] float speed = 2; // �G�̓����X�s�[�h
    [SerializeField] int _power;
    private float hidari;
    private float migi;

    private void Start()
    {
        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        enemy1Tr = transform;
        //�A�j���[�V�����̉E�����ƍ�����
        hidari = transform.localScale.x;
        migi = transform.localScale.x * -1;
    }

    private void Update()
    {

        // �v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�
        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            return;

        // �v���C���[�Ɍ����Đi��
        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);

        //�A�j���[�V�����̌�����ς���
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
