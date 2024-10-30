using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class result : MonoBehaviour
{
    public float _time;
    public int _knockOutAmount;
    public TextMeshProUGUI score_text;
    public float score_num;//スコア変数
    public int continue_count;
    public NameInput nameInput;

    // Start is called before the first frame update
    void Start()
    {
        score_num = _time + _knockOutAmount * continue_count;
        
    }

    // Update is called once per frame
    void Update()
    {
        score_num = _time + _knockOutAmount * continue_count;
        score_text.text = "クリアタイム : " + _time + "\n倒した敵の数 : " + _knockOutAmount  + "\nスコアボーナス : " + continue_count + "\nスコア : " + score_num + "\nランキング登録名:";
    }
    
    public void RankingUpdate()
    {
        int name = 0;
        int score = 1;
        string ranking;
        ranking = PlayerPrefs.GetString("DigitalNightfallRanking", "No Name,1000,No Name,900,No Name,800,No Name,700,No Name,600,No Name,500,No Name,400,No Name,300,No Name,200,No Name,100");
        string[] split = ranking.Split(',');
        string[] Name = new string[11];
        float[] Score = new float[11];
        for (int i = 0; i < 10; i++)
        {
            Name[i] = split[name];
            Score[i] = float.Parse(split[score]);
            name = name + 2;
            score = score + 2;
        }

        Name[10] = nameInput.name;
        Debug.Log(string.IsNullOrEmpty(Name[10]));
        Debug.Log(Name[10]);
        if (string.IsNullOrEmpty(Name[10]))
        {
            Name[10] = "No Name";
        }
        Score[10] = score_num;
        Array.Sort(Score);
        Array.Reverse(Score);
        int change = 0;

        for (int i = 0; i < Score.Length; i++)
        {
            if (Score[i] == score_num)
            {
                change = i; // 新しい値のインデックスを返す
            }
        }

        for (int i = 0; i < Name.Length - 1 - change; i++)
        {
            Name[Name.Length - i - 1] = Name[Name.Length - i - 2];
        }

        Name[change] = nameInput.name;
        if (string.IsNullOrEmpty(Name[change]))
        {
            Name[change] = "名無し";
        }
        string saveranking = "";
        for (int i = 0; i < 10; i++)
        {
            if (i < 9)
            {
                saveranking += Name[i] + "," + Score[i] + ",";
            }
            else
            {
                saveranking += Name[i] + "," + Score[i];
            }
        }

        PlayerPrefs.SetString("DigitalNightfallRanking", saveranking);

    }
}
