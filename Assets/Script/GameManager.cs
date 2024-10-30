using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverUI;

    private float _time;

    private int _knockOutAmount;

    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1.0f;
        _time = 120.0f;
        _knockOutAmount = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 180.0f)
        {
            SceneManager.LoadScene("Score");
        }
    }

    public void _ShowGameOverUI()
    {
        _gameOverUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public float _GetTime()
    {
        return _time;
    }

    public int _GetKnockOutAmount()
    {
        return _knockOutAmount;
    }

    public void _AddKnockOutAmount()
    {
        _knockOutAmount++;
    }
}
