using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList;    // 生成オブジェクト
    float minX, maxX, minY, maxY;   
    int frame = 0;                // 生成範囲
    [SerializeField] int generateFrame = 30;    // 生成する間隔
    public int maxObjects = 0;//最大生成数


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

                // ランダムで種類と位置を決める
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
