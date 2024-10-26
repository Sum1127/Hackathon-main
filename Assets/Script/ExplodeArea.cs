using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeArea : MonoBehaviour
{
    private int _power;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHP>().TakeDamage(_power);
            
        }
    }

    public void _SetPower(int _para)
    {
        _power = _para;
    }


}
