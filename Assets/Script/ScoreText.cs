using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour
{
    private float _time;
    private int _level;
    private int _knockOutAmount;

    private LevelManager _levelManager;
    private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _gameManager = FindObjectOfType<GameManager>();
        SceneManager.sceneLoaded += KeepScore;
    }

    // Update is called once per frame
    void Update()
    {
        _time = _gameManager._GetTime();
        _level = _levelManager._GetLevel();
        _knockOutAmount = _gameManager._GetKnockOutAmount();
        int minutes = (int)_time / 60;
        int seconds = (int)_time % 60;
        float miliseconds = _time - Mathf.Floor(_time);
        int milisecondsInt = Mathf.RoundToInt(miliseconds * 100);

        _textMeshPro.text = "KnockOut:" + _knockOutAmount + "\nTime " + minutes + ":" + seconds.ToString("00") + ":" + milisecondsInt + "\nPlayer Lv." + _level ;
    }

    void KeepScore(Scene next, LoadSceneMode mode)
    {
        // 次のシーンの中にあるオブジェクトを取得
        // そのオブジェクトに付加されているスクリプトを取得
        if (GameObject.Find("clearscore") == null) return;

        var result = GameObject.Find("clearscore").GetComponent<result>();

        result._time = _time;
        result._knockOutAmount = _knockOutAmount;//スコアを移す


        // イベントの削除
        SceneManager.sceneLoaded -= KeepScore;
    }
}
