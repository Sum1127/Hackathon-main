using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    Transform playerTr; // �v���C���[��Transform
    [SerializeField] float speed = 4; // �G�̓����X�s�[�h
    [SerializeField] GameObject Player;
    public float time = 0;
    [SerializeField] int _power;
    [SerializeField] GameObject Attacktype;
    private void Start()
    {
        // �v���C���[��Transform���擾�i�v���C���[�̃^�O��Player�ɐݒ�K�v�j
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

        // �v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�
        if (Vector2.Distance(transform.position, playerTr.position) < 15f)
            return;

        // �v���C���[�Ɍ����Đi��
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
