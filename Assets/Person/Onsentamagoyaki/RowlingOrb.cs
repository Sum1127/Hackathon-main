using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowlingOrb : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, Time.deltaTime*_rotateSpeed);
    }

}
