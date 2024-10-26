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
    public int continue_count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_time);
        score_num = _time + _knockOutAmount * continue_count;
        score_text.text = "ClearTime : " + _time + "\nKnockOut : " + _knockOutAmount  + "\nContinue : " + continue_count + "\nScore : " + score_num ;
    }
}
