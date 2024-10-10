using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour,IBullet
{

    [SerializeField] private float _speed;
    [SerializeField] private float _power;

    private Vector3 _shotDir;
    private Rigidbody2D _rigidbody2D;

    public void _SetShotDir(Vector2 Dir)
    {
        _shotDir = Dir;
    }

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

    private IEnumerator _Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
