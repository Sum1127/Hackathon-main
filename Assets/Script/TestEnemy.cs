using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public GameObject objectToSpawn;     // ��������I�u�W�F�N�g�iPrefab�Ȃǁj
    public Transform spawnPosition;      // ��������ʒu
    public float spawnInterval = 5f;     // �I�u�W�F�N�g�����������Ԋu
    Transform playerTr; // �v���C���[��Transform
    [SerializeField] float speed = 10; // �G�̓����X�s�[�h

    private GameObject currentSpawnedObject;  // ���ݐ�������Ă���I�u�W�F�N�g

    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        // ���Ԋu�ŃI�u�W�F�N�g�𐶐�
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void Update()
    {
        // �v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�
        if (Vector2.Distance(transform.position, playerTr.position) < 3f)
            return;

        // �v���C���[�Ɍ����Đi��
        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);
    }

    void SpawnObject()
    {
        // ���łɐ������ꂽ�I�u�W�F�N�g������ꍇ�͔j������

        // �V�����I�u�W�F�N�g���w��ʒu�ɐ���
        currentSpawnedObject = Instantiate(objectToSpawn, spawnPosition.position, Quaternion.identity);

        // ���������I�u�W�F�N�g��HP����������
        EnemyHP enemy = currentSpawnedObject.GetComponent<EnemyHP>();
        if (enemy != null)
        {
            enemy.InitHP(100);  // HP�������� (��Ƃ���100�ɐݒ�)
        }
    }
}
