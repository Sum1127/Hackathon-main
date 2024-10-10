using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList;    // 生成オブジェクト
    float minX, maxX, minY, maxY;   
    //int frame = 0;                // 生成範囲
    //[SerializeField] int generateFrame = 30;    // 生成する間隔
    public int maxObjects = 0;//最大生成数
    public float time = 0;//時間


    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x - 3f;
        maxX = Camera.main.ViewportToWorldPoint(Vector2.one).x + 3f;
        minY = Camera.main.ViewportToWorldPoint(Vector2.zero).y - 3f;
        maxY = Camera.main.ViewportToWorldPoint(Vector2.one).y + 3f;
        //++frame;
        if (maxObjects < 1000)
        {
            if (time > 3f)
            {
                //frame = 0;

                // ランダムで種類と位置を決める
                for (int i = 0; i < 5; i++)
                {
                    int index = Random.Range(0, enemyList.Count);
                    float posX = Random.Range(minX, maxX);
                    float posY = Random.Range(minY, maxY);
                    Vector2 enemyPosition1 = new Vector2(posX, minY);
                    Vector2 enemyPosition2 = new Vector2(posX, maxY);
                    Vector2 enemyPosition3 = new Vector2(minX, posY);
                    Vector2 enemyPosition4 = new Vector2(maxX, posY);

                    //Camera.main.ViewportToWorldPoint(new Vector3(-3f+posX, -3f+posY, Camera.main.nearClipPlane));
                    //enemyPosition.z = 0;
                    Instantiate(enemyList[index], enemyPosition1, Quaternion.identity);
                    Instantiate(enemyList[index], enemyPosition2, Quaternion.identity);
                    Instantiate(enemyList[index], enemyPosition3, Quaternion.identity);
                    Instantiate(enemyList[index], enemyPosition4, Quaternion.identity);
                    maxObjects += 4;
                }
                time = 0;            
            }
        }
    }
}
