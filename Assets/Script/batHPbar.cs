using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class batHPbar : MonoBehaviour
{
    [SerializeField] public float batmaxHP; //ç≈ëÂÇÃHP
    public batmove batmovescript; //åªç›ÇÃHP
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
