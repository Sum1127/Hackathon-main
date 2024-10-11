using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int _targetAmount;

    private int _level;

    private int _enemyAmount;

    private GameObject _ClearUI;
    private LevelClear _levelClear;
    

    private void Awake()
    {
        _targetAmount = 20;
        _enemyAmount = 20;
        _level = 1;
        _ClearUI = GameObject.Find("ClearUI");
        _levelClear = FindObjectOfType<LevelClear>();
        _ClearUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (_enemyAmount <= 0)
        {
            //Debug.Log("ƒŒƒxƒ‹" + _level+"ƒNƒŠƒA!!");

            StartCoroutine(_DisplayClear());

            _targetAmount += 20;          
            _enemyAmount = _targetAmount;
            //Debug.Log(_targetAmount);
            Time.timeScale = 0.0f;
        }
    }

    public void _DefeatEnemy()
    {
        _enemyAmount--;
        //Debug.Log(_enemyAmount);
    }

    IEnumerator _DisplayClear()
    {
        _ClearUI.SetActive(true);
        _levelClear._DisplayLevelClear(_level);
        yield return new WaitForSeconds(0.15f);
        _ClearUI.SetActive(false);
        _level++;
    }


}
