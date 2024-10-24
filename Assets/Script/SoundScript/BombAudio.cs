using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAudio : MonoBehaviour
{
    public GameObject Audio_Object;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(Audio_Object, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
