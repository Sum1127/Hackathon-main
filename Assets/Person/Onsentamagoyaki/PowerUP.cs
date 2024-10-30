using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PowerUP : MonoBehaviour
{


    [SerializeField] private Player _player;
    [SerializeField] private PlayerHP _playerHP;

    private int[] _buttonIndex;
    private int[] _powerUPIndex;


    [SerializeField] private TextMeshProUGUI[] _powerUPtext;


    // Start is called before the first frame update
    void Start()
    {
        _buttonIndex = new int[_powerUPtext.Length];
        _powerUPIndex = new int[8];
     
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void _ChangePowerUPtext()
    {
        for(int i = 0;  i < _powerUPtext.Length; i++)
        {
            _powerUPIndex[i] = Random.Range(0, _powerUPIndex.Length);
            _SetPowerUPMassage(_powerUPIndex[i],i);
        }

    }

    public void _PowerUP(int ButtonIndex)
    {
        _SetPowerUP(_powerUPIndex[ButtonIndex]);
    }


    private void _SetPowerUPMassage(int PowerUPindex, int ButtonIndex )
    {
        switch (PowerUPindex)
        {
            case 0:
                _powerUPtext[ButtonIndex].text = "\nHP回復";
                break;

            case 1:
                _powerUPtext[ButtonIndex].text = "\n最大HP増加";
                break;

            case 2:
                _powerUPtext[ButtonIndex].text = "剣　\n 攻撃力UP";
                break;

            case 3:
                _powerUPtext[ButtonIndex].text = "銃　\n 攻撃力UP";
                break;

            case 4:
                _powerUPtext[ButtonIndex].text = "オーブ　\n 攻撃力UP";
                break;

            case 5:
                _powerUPtext[ButtonIndex].text = "オーブ　\n 速度UP";
                break;

            case 6:
                _powerUPtext[ButtonIndex].text = "ボム　\n 範囲UP";
                break;

            case 7:
                _powerUPtext[ButtonIndex].text = "移動速度増加";
                break;


        }
    }

    private void _SetPowerUP(int PowerUPindex)
    {
        switch (PowerUPindex)
        {
            case 0:
                _playerHP._SetHP(200);
                break;

            case 1:
                _playerHP._SetMaxHP(100);
                break;

            case 2:
                _player._SetSwordPower(50);
                break;

            case 3:
                _player._bulletPow = (20);
                break;

            case 4:
                _player._SetOrbPower(20);
                break;

            case 5:
                _player._SetOrbSpeed(30);
                break;

            case 6:
                _player._bombScale += 0.5f;
                break;

            case 7:
                _player._moveSpeed += 0.5f;
                break;


        }

        Time.timeScale = 1.0f;
        Debug.Log("強くてニューゲーム");
    }
}
