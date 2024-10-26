using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPBottun : MonoBehaviour
{
    GameObject _powerUPManager;
    [SerializeField] private int _buttonIndex;

    // Start is called before the first frame update
    void Start()
    {
        _powerUPManager = GameObject.Find("PowerUPManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _PowerUP()
    {
        _powerUPManager.GetComponent<PowerUP>()._PowerUP(_buttonIndex);
    }
}
