using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

   
    [SerializeField] private ParticleSystem _effect;
    public GameObject Audio_Obj;
    
    private bool _isPlaying = false;
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
       
        StartCoroutine(_Explode());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           
            StartCoroutine(_Explode());
        }
    }

    private IEnumerator _Explode()
    {
        
        if (_isPlaying) yield break;
        _isPlaying = true;
        var _effct = Instantiate(_effect, transform.position, _effect.transform.rotation);
        Instantiate(Audio_Obj, transform.position, transform.rotation);
        transform.GetChild(0).gameObject.SetActive(true);
        yield return null;
        transform.GetChild(0).gameObject.transform.parent = _effct.transform;
        yield return null;
        Destroy(gameObject);
    }



}
