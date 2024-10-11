using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _playerMinPosx;
    [SerializeField] private float _playerMaxPosx;
    [SerializeField] private float _playerMinPosy;
    [SerializeField] private float _playerMaxPosy;

    private Vector2 _movedir;

    private Rigidbody2D _rigidbody2D;

    private GameObject _meleeWeapon;

    [SerializeField] private TrailRenderer[] _trailRenderer;

    [SerializeField] private GameObject _bulletWeapon;

    [SerializeField] private GameObject _bomb;

    private bool _bShot;
    private bool _bRecastShot;
    private bool _bRecastBomb;

    // Start is called before the first frame update
    void Start()
    {
       _meleeWeapon=transform.GetChild(0).gameObject;
       _bShot = false;
       _bRecastShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        if (_bShot&&!_bRecastShot) StartCoroutine(_Shot());

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movedir = context.ReadValue<Vector2>();        
    }

    public void _Move()
    {
        transform.Translate(_movedir * _moveSpeed * Time.deltaTime);
        float _currentPosx = transform.position.x;
        float _currentPosy = transform.position.y;
        Vector3 _playerPos = new Vector3(Mathf.Clamp(_currentPosx, _playerMinPosx, _playerMaxPosx), Mathf.Clamp(_currentPosy, _playerMinPosy, _playerMaxPosy), transform.position.z);
        transform.position = _playerPos;
    }

    public void _OnAttack(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (_meleeWeapon.activeSelf)return;

        Vector3 _clickPos = Mouse.current.position.ReadValue();
        _clickPos = Camera.main.ScreenToWorldPoint(_clickPos);
        _clickPos.z = 0.0f; 

        Vector3 direction = _clickPos - transform.position;

        Vector2 _shotDir = new Vector2(direction.x, direction.y);
        _shotDir.Normalize();

        // 角度を計算
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg)+180.0f; // ラジアンから度に変換

        _meleeWeapon.SetActive(true);
        StartCoroutine(_Attack(angle));      
    }

    public void _OnShot(InputAction.CallbackContext context)
    {
        if (context.started) _bShot = true;
        else if (context.canceled) _bShot = false;   
    }

    private IEnumerator _Attack(float Angle)
    {
        _meleeWeapon.transform.eulerAngles = new Vector3(0.0f,0.0f,Angle);

        float cnt=0.0f;

        while (cnt < 180.0f)
        {
            _meleeWeapon.transform.Rotate(0, 0, 800 * Time.deltaTime);
            cnt += 800 * Time.deltaTime;
            yield return null;
        }


        foreach (TrailRenderer trailRenderer in _trailRenderer)
        {
            trailRenderer.Clear();
        }
          
        _meleeWeapon.SetActive(false);

        _meleeWeapon.transform.eulerAngles = Vector3.zero;
       

    }

    private IEnumerator _Shot()
    {
        _bRecastShot = true;

        Vector3 _clickPos = Mouse.current.position.ReadValue();
        _clickPos = Camera.main.ScreenToWorldPoint(_clickPos);
        _clickPos.z = 0.0f;

        Vector3 direction = _clickPos - transform.position;

        Vector2 _shotDir = new Vector2(direction.x, direction.y);
        _shotDir.Normalize();

        GameObject shot = Instantiate(_bulletWeapon, transform.position, _bulletWeapon.transform.rotation);
        shot.GetComponent<IBullet>()._SetShotDir(_shotDir);

        yield return new WaitForSeconds(0.05f);
        _bRecastShot=false;

    }

    public void _OnSetBomb(InputAction.CallbackContext context)
    {
        if (!context.started||_bRecastBomb) return;
        StartCoroutine(_SetBomb());
    }

    private IEnumerator _SetBomb()
    {
        _bRecastBomb = true;
        Instantiate(_bomb, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3.0f);
        _bRecastBomb = false;
    }

}
