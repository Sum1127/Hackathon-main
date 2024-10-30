using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float _moveSpeed;
    [SerializeField] private float _playerMinPosx;
    [SerializeField] private float _playerMaxPosx;
    [SerializeField] private float _playerMinPosy;
    [SerializeField] private float _playerMaxPosy;

    private Vector2 _movedir;
    private Vector2 _aimDir;

    private Rigidbody2D _rigidbody2D;

    private GameObject _meleeWeapon;

    [SerializeField] private TrailRenderer[] _trailRenderer;

    [SerializeField] private GameObject _bulletWeapon;

    [SerializeField] private GameObject _bomb;

    private bool _bShot;
    private bool _bRecastShot;
    private bool _bRecastBomb;
    public AudioClip Orbsound;
    public AudioClip Swordsound;
    public AudioClip Bulletsound;
    public AudioClip Bombsound;
    AudioSource audioSource;
    private float time=0;


    public int _bulletPow = 100;
    public int _bombPow=200;
    public int _bulletSpeed = 40;
    public float _bombScale = 3.0f;


    private Orb[] _orbs;
    private RowlingOrb[] _orbAxis;
    private GameObject _sword;
  

    // Start is called before the first frame update
    void Start()
    {
       _meleeWeapon=transform.GetChild(0).gameObject;
       _bShot = false;
       _bRecastShot = false;
       audioSource = GetComponent<AudioSource>();
       _orbs = GetComponentsInChildren<Orb>();
       _orbAxis =GetComponentsInChildren<RowlingOrb>();
       _sword = GetComponentInChildren<Sword>().gameObject;
       _meleeWeapon.SetActive(false);
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        _Move();
        if (_bShot&&!_bRecastShot) StartCoroutine(_Shot());
        if(time>=3)
        {
            audioSource.PlayOneShot(Orbsound);
            time = 0;
        }
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

        Vector2 _shotDir;

        if (_aimDir == Vector2.zero)
        {
            Vector3 _clickPos = Mouse.current.position.ReadValue();
            _clickPos = Camera.main.ScreenToWorldPoint(_clickPos);
            _clickPos.z = 0.0f;

            Vector3 direction = _clickPos - transform.position;

            _shotDir = new Vector2(direction.x, direction.y);
            _shotDir.Normalize();
        }
        else
        {
            _shotDir = _aimDir;
            _shotDir.Normalize();
        }

        // 角度を計算
        float angle = (Mathf.Atan2(_shotDir.y, _shotDir.x) * Mathf.Rad2Deg)+180.0f; // ラジアンから度に変換

        _meleeWeapon.SetActive(true);
        audioSource.PlayOneShot(Swordsound);
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
        Vector2 _shotDir;

        _bRecastShot = true;
        if (_aimDir == Vector2.zero)
        {
            Vector3 _clickPos = Mouse.current.position.ReadValue();
            _clickPos = Camera.main.ScreenToWorldPoint(_clickPos);
            _clickPos.z = 0.0f;

            Vector3 direction = _clickPos - transform.position;

            _shotDir = new Vector2(direction.x, direction.y);
            _shotDir.Normalize();
        }
        else
        {
            _shotDir = _aimDir;
        }

        GameObject shot = Instantiate(_bulletWeapon, transform.position, _bulletWeapon.transform.rotation);
        shot.GetComponent<IBullet>()._SetShotDir(_shotDir);
        shot.GetComponent<Bullet>()._SetPower(_bulletPow);
        shot.GetComponent<Bullet>()._SetSpeed(_bulletSpeed);

        yield return new WaitForSeconds(0.05f);
        _bRecastShot=false;
        audioSource.PlayOneShot(Bulletsound);

    }

    public void _OnSetBomb(InputAction.CallbackContext context)
    {
        if (!context.started||_bRecastBomb) return;
        StartCoroutine(_SetBomb());
    }

    private IEnumerator _SetBomb()
    {
        audioSource.PlayOneShot(Bombsound);
        _bRecastBomb = true;
        var bomb = Instantiate(_bomb, transform.position, Quaternion.identity)as GameObject;
        bomb.transform.GetChild(0).gameObject.GetComponent<ExplodeArea>()._SetPower(_bombPow);
        bomb.transform.localScale = _bombScale*Vector3.one;
        yield return new WaitForSeconds(3.0f);
        _bRecastBomb = false;
    }

    public void _SetOrbPower(int _para)
    {
        foreach (var orb in _orbs)
        {
            orb._power += _para;
        }
    }

    public void _SetOrbSpeed(float _para)
    {
        foreach (var orb in _orbAxis)
        {
            orb._rotateSpeed += _para;
        }
    }

    public void _SetSwordPower(int _para)
    {
        _sword.GetComponent<Sword>()._power += _para;            
    }

    public void _SetSwordScale(float _para)
    {

        _sword.transform.localScale +=  new Vector3(0.0f , _para,0.0f);
        _sword.transform.position += new Vector3(0.0f, _para / 2, 0.0f);

    }

    public void _OnAim(InputAction.CallbackContext context)
    {
        _aimDir = context.ReadValue<Vector2>();
    }



}
