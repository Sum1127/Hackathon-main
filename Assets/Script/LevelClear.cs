using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelClear : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _textMeshPro;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _DisplayLevelClear()
    {
        _textMeshPro.text = "  Level  UP !! " ;
    }

}
