using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Bullet : MonoBehaviour
{
    Transform playerTr; // プレイヤーのTransform
    [SerializeField] float speed = 10; // 敵の動くスピード
    public float lifetime = 8f;
    [SerializeField] int _power;



    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 dir = (playerTr.position - this.transform.position);

        // ここで向きたい方向に回転させてます
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
