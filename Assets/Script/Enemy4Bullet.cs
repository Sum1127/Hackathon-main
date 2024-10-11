using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Bullet : MonoBehaviour
{
    Transform playerTr; // �v���C���[��Transform
    [SerializeField] float speed = 10; // �G�̓����X�s�[�h
    public float lifetime = 8f;
    [SerializeField] int _power;



    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 dir = (playerTr.position - this.transform.position);

        // �����Ō������������ɉ�]�����Ă܂�
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().TakeDamage(_power);
            Destroy(gameObject);
        }
    }

}
