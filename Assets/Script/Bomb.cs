using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

   
    [SerializeField] private ParticleSystem _effect;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_Destroy());
    }

    // Update is called once per frame
    void Update()
    {
    
    }
  
    private IEnumerator _Destroy()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(_effect,transform.position,_effect.transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(_effect, transform.position, _effect.transform.rotation);
            Destroy(gameObject);
        }
    }
}
