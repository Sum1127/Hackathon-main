using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Enemy7 : MonoBehaviour
{
    Transform playerTr; // プレイヤーのTransform
    [SerializeField] float speed = 30; // 敵の動くスピード
    [SerializeField] int _power;
    private bool isMoving = true;
    public float flashSpeed = 0.2f;        // 点滅速度（秒）
    public float flashDuration = 2f;       // 点滅する時間
    private bool isFlashing = false;       // 点滅中かどうか
    private Renderer objRenderer;

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        if (objRenderer == null)
        {
            objRenderer = GetComponent<Renderer>();
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            if (Vector2.Distance(transform.position, playerTr.position) > 3f)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    new Vector2(playerTr.position.x, playerTr.position.y),
                    speed * Time.deltaTime);
            }
            else
            {
                StartCoroutine(StartFlashing());
            }
        }


    }

    IEnumerator StartFlashing()
    {
        isFlashing = true;
        isMoving = false;
        GameObject deleteObject = gameObject;
        float FlashEndTime = Time.time + flashDuration;

        // 高速で点滅
        while (Time.time < FlashEndTime)
        {
            objRenderer.enabled = !objRenderer.enabled;  // レンダラーをON/OFF切り替え
            yield return new WaitForSeconds(flashSpeed); // 点滅間隔
        }

        // 最後にレンダラーをONにする
        objRenderer.enabled = true;

        // オブジェクトを消滅させる
        Destroy(deleteObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().TakeDamage(_power);
        }
    }

}
