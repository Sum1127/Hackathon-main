using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class batHPbar : MonoBehaviour
{
    [SerializeField] public float batmaxHP; //最大のHP
    public batmove batmovescript; //現在のHP
    float batHP;
    public SliderJoint2D slider;
    // Start is called before the first frame update
    void Start()
    {
        //slider.value = batmaxHP;
        batHP = batmovescript.batHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
