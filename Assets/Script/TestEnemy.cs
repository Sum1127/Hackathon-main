using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public GameObject objectToSpawn;     // 生成するオブジェクト（Prefabなど）
    public Transform spawnPosition;      // 生成する位置
    public float spawnInterval = 5f;     // オブジェクトが生成される間隔
    Transform playerTr; // プレイヤーのTransform
    [SerializeField] float speed = 10; // 敵の動くスピード

    private GameObject currentSpawnedObject;  // 現在生成されているオブジェクト

    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        // 一定間隔でオブジェクトを生成
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void Update()
    {
        // プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector2.Distance(transform.position, playerTr.position) < 3f)
            return;

        // プレイヤーに向けて進む
        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);
    }

    void SpawnObject()
    {
        // すでに生成されたオブジェクトがある場合は破棄する

        // 新しいオブジェクトを指定位置に生成
        currentSpawnedObject = Instantiate(objectToSpawn, spawnPosition.position, Quaternion.identity);

        // 生成したオブジェクトにHPを持たせる
        EnemyHP enemy = currentSpawnedObject.GetComponent<EnemyHP>();
        if (enemy != null)
        {
            enemy.InitHP(100);  // HPを初期化 (例として100に設定)
        }
    }
}
