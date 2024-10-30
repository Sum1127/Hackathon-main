using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class rankingsave : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        int name = 0;
        int score = 1;
        string ranking;
        ranking = PlayerPrefs.GetString("DigitalNightfallRanking", "No Name,1000,No Name,900,No Name,800,No Name,700,No Name,600,No Name,500,No Name,400,No Name,300,No Name,200,No Name,100");
        string[] split = ranking.Split(',');
        string[] Name = new string[10];
        string[] Score=new string[10];
        for(int i=0;i<10;i++)
        {
            Name[i] = split[name];
            Score[i] = split[score];
            name = name + 2;
            score = score + 2;
        }


        text.text = "";
        string rank;

        for(int i=0;i<10;i++)
        {
            rank = (i+1).ToString();
            text.text +=  rank + "ˆÊ" + " " + Name[i] + ":" + Score[i] + "\n";
        }

    }

}
