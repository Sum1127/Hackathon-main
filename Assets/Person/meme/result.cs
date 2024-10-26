using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class result : MonoBehaviour
{
    public float _time;
    public int _knockOutAmount;
    public TextMeshProUGUI score_text;
    public float score_num;//ÉXÉRÉAïœêî

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_time);
        score_num = _time + _knockOutAmount;
        score_text.text = "ClearTime : " + _time + "\nknockOut : " + _knockOutAmount + "\nScore : " + score_num;
    }
}
