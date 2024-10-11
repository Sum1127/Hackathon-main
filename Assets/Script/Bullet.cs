using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IBullet
{
    [SerializeField] private float _speed;
    [SerializeField] private int _power;

    private Vector3 _shotDir;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(_Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = _shotDir * _speed;
    }

    public void _SetShotDir(Vector2 Dir)
    {
        _shotDir = Dir;
    }
    
    private IEnumerator _Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHP>().TakeDamage(_power);
        }
    }
}
