using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] float _playerMinPosx;
    [SerializeField] float _playerMaxPosx;
    [SerializeField] float _playerMinPosy;
    [SerializeField] float _playerMaxPosy;

    private Vector2 _movedir;

    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_movedir * _moveSpeed * Time.deltaTime);
        float _currentPosx = transform.position.x;
        float _currentPosy = transform.position.y;
        Vector3 _playerPos = new Vector3(Mathf.Clamp(_currentPosx, _playerMinPosx, _playerMaxPosx), Mathf.Clamp(_currentPosy, _playerMinPosy, _playerMaxPosy), transform.position.z);
        transform.position = _playerPos;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movedir = context.ReadValue<Vector2>();        
    }
}
