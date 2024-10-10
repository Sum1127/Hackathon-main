using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList;    // �����I�u�W�F�N�g
    float minX, maxX, minY, maxY;   
    int frame = 0;                // �����͈�
    [SerializeField] int generateFrame = 30;    // ��������Ԋu
    public int maxObjects = 0;//�ő吶����


    void Start()
    {

    }

    void Update()
    {
        ++frame;
        if (maxObjects < 1000)
        {
            if (frame > generateFrame)
            {
                frame = 0;

                // �����_���Ŏ�ނƈʒu�����߂�
                int index = Random.Range(0, enemyList.Count);
                float posX = Random.Range(3,5);
                float posY = Random.Range(3,5);
                Vector3 enemyPosition = Camera.main.ViewportToWorldPoint(new Vector3(-3f+posX, -3f+posY, Camera.main.nearClipPlane));
                enemyPosition.z = 0;
                Instantiate(enemyList[index],enemyPosition , Quaternion.identity);
                ++maxObjects;
            }
        }
    }
}
