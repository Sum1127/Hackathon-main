using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class clearscore : MonoBehaviour
{
    public TextMeshProUGUI score_text;
    public float score_num;//ÉXÉRÉAïœêî
    public float _time;
    public int _knockOutAmount;
    //public resultScript result;

    // Start is called before the first frame update
    void Start()
    {
        score_num = 0;
        //result = result.GetComponent<resultScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //_time = result .time;
        //_knockOutAmount = result .knockOutAmount;
        score_num = _time + _knockOutAmount;
        score_text.text = "ClearTime"+ _time + "\nknockOut" + _knockOutAmount + "\nScore:" + score_num;
        
    }
}
