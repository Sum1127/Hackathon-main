using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] float _cameraMinPosx;
    [SerializeField] float _cameraMaxPosx;
    [SerializeField] float _cameraMinPosy;
    [SerializeField] float _cameraMaxPosy;


    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _FollowPlayer();
    }

    private void _FollowPlayer()//ÉvÉåÉCÉÑÅ[Çí«ê’Ç∑ÇÈèàóù
    {
        float _currentPosx = _player.transform.position.x;
        float _currentPosy = _player.transform.position.y;
        Vector3 _playerPos = new Vector3(Mathf.Clamp(_currentPosx, _cameraMinPosx, _cameraMaxPosx), Mathf.Clamp(_currentPosy, _cameraMinPosy, _cameraMaxPosy), transform.position.z);
        transform.position = _playerPos;
    }
}
